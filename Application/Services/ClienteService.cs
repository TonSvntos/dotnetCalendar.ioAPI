using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces.Command;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using ClosedXML.Excel;
using System.ComponentModel;

namespace Application.Services
{
    public class ClientesService : ApplicationBase, IClientesService
    {
        public vmClientes InsertCliente(vmClientes insCliente)
        {
            var rep = GetService<IInsertCliente>();

            ClientesDomain param = DataHelper.Read<ClientesDomain>(insCliente);

            var item = rep.Execute(param);

            var result = ConvertToViewModel(item);

            return result;
        }

        public vmClientes UpdateCliente(vmClientes updCliente)
        {

            var verifyId = ListClienteById(updCliente.ClienteId);

            if (verifyId.Count == 0)
            {
                return null;
            }

            var rep = GetService<IUpdateCliente>();

            ClientesDomain param = DataHelper.Read<ClientesDomain>(updCliente);

            var item = rep.Execute(param);

            var result = ConvertToViewModel(item);

            return result;
        }

        public void ConfirmPayment(vmClientes clientes)
        {
            var rep = GetService<IUpdateCliente>();

            ClientesDomain param = DataHelper.Read<ClientesDomain>(clientes);

            rep.ConfirmPayment(param);

        }

        public List<vmClientes> ListCliente(vmClientes filter)
        {
            ClientesDomain param = DataHelper.Read<ClientesDomain>(filter);

            var rep = GetService<IListCliente>();

            List<ClientesDomain> lstClientes = rep.Execute(param);

            return ConvertModelToViewModel(lstClientes);

        }

        public List<vmClientes> ListOrcamentos( )
        {
            

            var rep = GetService<IListCliente>();

            List<ClientesDomain> lstClientes = rep.ListOrcaments();

            return ConvertModelToViewModel(lstClientes);

        }

        public List<vmClientes> GetAllClients()
        {

            var rep = GetService<IListCliente>();

            List<ClientesDomain> lstClientes = rep.GetAllClients();

            return ConvertModelToViewModel(lstClientes);

        }

        public List<vmClientes> ListClienteById(long produtoId)
        {
            var rep = GetService<IListClienteById>();

            List<ClientesDomain> lstCliente = rep.Execute(produtoId);

            return ConvertModelToViewModel(lstCliente);

        }

        private List<vmClientes> ConvertModelToViewModel(List<ClientesDomain> domainModelList)
        {
            var _list = DataHelper.List<vmClientes>(domainModelList);
            return _list;
        }


        public vwReturnFiles GenerateExcel(List<Meses> meses)
        {
            vwReturnFiles result = new vwReturnFiles();

            string nameFile = "Relatorio de pagamentos";
            var rep = GetService<IListCliente>();

            //List<ClientesDomain> lst = rep.ListOrcaments();


            //DataTable table = new DataTable();

            //// Adicione todas as propriedades do seu objeto
            //table.Columns.Add("Mes", typeof(string));
            //table.Columns.Add("Orcamento", typeof(double));
            //table.Columns.Add("Pagamento", typeof(double));


            //foreach (var obj in meses)
            //{
            //    table.Rows.Add(

            //        obj.Mes,
            //        obj.DebitNoteDocumentNumber,
            //        obj.DebitNoteNumber);
            // }

            DataTable dt = ConvertToDataTable(meses);



            if ((dt != null && dt.Rows.Count > 0))
            {
                dt = FormatExcel(dt);
                XLWorkbook wb = new XLWorkbook();
                IXLWorksheet wsBloqueado = wb.Worksheets.Add(dt, nameFile);
                //Corrigindo tamanho de colunas.
                wsBloqueado.Columns().AdjustToContents();

                using (var memoryStream = new MemoryStream())
                {
                    wb.SaveAs(memoryStream);
                    memoryStream.Position = 0;
                    result.content = System.Convert.ToBase64String(memoryStream.ToArray());
                    result.nmFile = nameFile;
                }
            }

            return result;
        }

        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            if (data != null && data.Count != 0)
            {
                PropertyDescriptorCollection properties =
                   TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    table.Rows.Add(row);
                }
                return table;
            }
            else
            {
                return null;
            }
        }


        private DataTable FormatExcel(DataTable dt)
        {
            dt.Columns["Mes"].ColumnName = "Mes";
            dt.Columns["Orcamento"].ColumnName = "Orcamento";
            dt.Columns["Pagamento"].ColumnName = "Pagamento";
        


            return dt;
        }




        private vmClientes ConvertToViewModel(ClientesDomain d)
        {
            var item = new vmClientes
            {
                ClienteId = d.ClienteId,
                NomeCliente = d.NomeCliente,
                ClienteBairro = d.ClienteBairro,
                ClienteEndereco = d.ClienteEndereco,
                DataDoAtendimento = d.DataDoAtendimento,

            };
            return item;
        }

       
    }
}

