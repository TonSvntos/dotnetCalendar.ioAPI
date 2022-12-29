using System.Collections.Generic;
using Domain.Models;


namespace Domain.Interfaces.Command
{
    public interface IListProduct
    {
        public List<ProdutosDomain> Execute(ProductsFilterDomain filter);

    }
}
