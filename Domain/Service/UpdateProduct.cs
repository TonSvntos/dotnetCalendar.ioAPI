using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Domain.Interfaces.Command;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Repository;

namespace Domain.Service
{
    internal class UpdateProduct : IUpdateProduct
    {
        public ProdutosDomain Execute(ProdutosDomain updProduct)
        {
            return DomainBase.Provider.GetService<IProductRepository>().UpdateProdutos(updProduct);
        }
    }
}
