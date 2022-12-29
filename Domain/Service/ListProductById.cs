using System.Collections.Generic;
using Domain.Models;
using Domain.Interfaces.Command;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Repository;

namespace Domain.Service
{
    public class ListProductById : IListProductById
    {
        public List<ProdutosDomain> Execute(long produtoId)
        {
            return DomainBase.Provider.GetService<IProductRepository>().ListProdutosDomainById(produtoId);
        }

    }
}
