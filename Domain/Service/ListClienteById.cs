using System.Collections.Generic;
using Domain.Models;
using Domain.Interfaces.Command;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Repository;

namespace Domain.Service
{
    public class ListClienteById : IListClienteById
    {
        public List<ClientesDomain> Execute(long produtoId)
        {
            return DomainBase.Provider.GetService<IClienteRepository>().ListClienteDomainById(produtoId);
        }

    }
}
