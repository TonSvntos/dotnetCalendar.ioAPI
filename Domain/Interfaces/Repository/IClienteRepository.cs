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
        public List<ClientesDomain> GetAllClients();
        public void ConfirmPayment(ClientesDomain cliente);
        public List<ClientesDomain> ListOrcaments();




        public ClientesDomain UpdateCliente(ClientesDomain cliente);
        public ClientesDomain InsertCliente(ClientesDomain cliente);



    }
}
