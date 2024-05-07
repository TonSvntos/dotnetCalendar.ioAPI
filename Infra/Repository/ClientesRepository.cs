using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Framework.Infra;
using Domain.Interfaces.Repository;

namespace Infra.Repository
{
    public class ClientesRepository : IClienteRepository
    {
        const PEnvironment.PDB db = PEnvironment.PDB.ProjectsDatabase;

        public ClientesDomain InsertCliente(ClientesDomain cliente)
        {
            Helper helper = new Helper();

            helper.ExecuteNonQuery(db, "dbo.spINSCliente", new
            {

                cliente.NomeCliente,
                cliente.TelefoneCliente,
                cliente.ClienteEndereco,
                cliente.ClienteBairro,
                cliente.DataDoAtendimento,
                cliente.TipoDeServico
                ,
                cliente.Cep
                ,
                cliente.Numero
                ,
                cliente.Complemento
                ,
                cliente.Cidade
                , cliente.Orcamento
            });

            return cliente;
        }

        public List<ClientesDomain> ListClienteDomain(ClientesDomain filter)
        {
            Helper helper = new Helper();

            return helper.ExecuteList<ClientesDomain>(db, "dbo.spLSTClientes", new
            {
                filter.NomeCliente,
                filter.TelefoneCliente,
                filter.ClienteEndereco,
                filter.ClienteBairro,
                filter.DataDoAtendimento,
                filter.TipoDeServico
            });
        }


        public List<ClientesDomain> ListOrcaments()
        {
            Helper helper = new Helper();

            return helper.ExecuteList<ClientesDomain>(db, "dbo.spLSTOrcamentos");
        }

        public List<ClientesDomain> GetAllClients()
        {
            Helper helper = new Helper();

            return helper.ExecuteList<ClientesDomain>(db, "dbo.spLSTAllClients");
        }

        public List<ClientesDomain> ListClienteDomainById(long clienteId)
        {
            Helper helper = new Helper();

            return helper.ExecuteList<ClientesDomain>(db, "dbo.spSELClienteById", new
            {
                ClienteId = clienteId
            });
        }

        public ClientesDomain UpdateCliente(ClientesDomain cliente)
        {
            Helper helper = new Helper();

            helper.ExecuteNonQuery(db, "dbo.spUPDCliente", new
            {
                cliente.ClienteId,
                cliente.NomeCliente,
                cliente.TelefoneCliente,
                cliente.ClienteEndereco,
                cliente.ClienteBairro,
                cliente.DataDoAtendimento,
                cliente.TipoDeServico
                     ,
                cliente.Cep
                ,
                cliente.Numero
                ,
                cliente.Complemento
                ,
                cliente.Cidade
                , cliente.Orcamento


            });

            return cliente;
        }

        public void ConfirmPayment(ClientesDomain cliente)
        {
            Helper helper = new Helper();

            //cliente.PagamentoConfirmado = !cliente.PagamentoConfirmado;

            helper.ExecuteNonQuery(db, "dbo.[spUpdPagamentoEfetuado]", new { cliente.ClienteId, cliente.PagamentoConfirmado });
        }


    }
}
