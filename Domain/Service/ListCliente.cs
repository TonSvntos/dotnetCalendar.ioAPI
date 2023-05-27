using System.Collections.Generic;
using Domain.Models;
using Domain.Interfaces.Command;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Repository;

namespace Domain.Service
{
    public class ListCliente : IListCliente
    {
        public List<ClientesDomain> Execute(ClientesDomain filter)
        {
            return DomainBase.Provider.GetService<IClienteRepository>().ListClienteDomain(filter);
        }
    }
}
