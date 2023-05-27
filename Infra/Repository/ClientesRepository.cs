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

        public ClientesDomain InsertCliente(ClientesDomain insCliente)
        {
            Helper helper = new Helper();

            helper.ExecuteNonQuery(db, "dbo.spINSCliente", new
            {

                insCliente.NomeCliente,
                insCliente.TelefoneCliente,
                insCliente.ClienteEndereco,
                insCliente.ClienteBairro,
                insCliente.DataDoAtendimento,
                insCliente.TipoDeServico
            });

            return insCliente;
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

        public List<ClientesDomain> ListClienteDomainById(long clienteId)
        {
            Helper helper = new Helper();

            return helper.ExecuteList<ClientesDomain>(db, "dbo.spSELClienteById", new
            {
                ClienteId = clienteId
            });
        }

        public ClientesDomain UpdateCliente(ClientesDomain updCliente)
        {
            Helper helper = new Helper();

            helper.ExecuteNonQuery(db, "dbo.spUPDCliente", new
            {
                updCliente.ClienteId,
                updCliente.NomeCliente,
                updCliente.TelefoneCliente,
                updCliente.ClienteEndereco,
                updCliente.ClienteBairro,
                updCliente.DataDoAtendimento,
                updCliente.TipoDeServico


            });

            return updCliente;
        }


        
    }
}
