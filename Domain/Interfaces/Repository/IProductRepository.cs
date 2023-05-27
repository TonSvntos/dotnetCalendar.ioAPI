using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        public List<ClientesDomain> ListClienteDomain(ClientesDomain filter);
        public List<ClientesDomain> ListClienteDomainById(long produtoId);

        public ClientesDomain UpdateCliente(ClientesDomain updProdutos);
        public ClientesDomain InsertCliente(ClientesDomain insProdutos);



    }
}
