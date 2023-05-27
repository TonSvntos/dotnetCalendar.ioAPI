using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces.Command;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public class ClientesService : ApplicationBase,IClientesService
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

        public List<vmClientes> ListCliente(vmClientes filter)
        {
            ClientesDomain param = DataHelper.Read<ClientesDomain>(filter);

            var rep = GetService<IListCliente>();

            List<ClientesDomain> lstClientes = rep.Execute(param);

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

