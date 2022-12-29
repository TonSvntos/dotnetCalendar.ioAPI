
using System.Collections.Generic;
using Domain.Models;


namespace Domain.Interfaces.Command
{
    public interface IListProductById
    {
        public List<ProdutosDomain> Execute(long productId);

    }
}
