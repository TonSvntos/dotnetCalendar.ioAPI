using System.Collections.Generic;
using Domain.Models;
using Domain.Interfaces.Command;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Repository;

namespace Domain.Service
{
    public class ListProduct : IListProduct
    {
        public List<ProdutosDomain> Execute(ProductsFilterDomain filter)
        {
            return DomainBase.Provider.GetService<IProductRepository>().ListProdutosDomain(filter);
        }
    }
}
