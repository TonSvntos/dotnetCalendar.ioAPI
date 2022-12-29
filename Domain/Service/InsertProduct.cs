using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.Command;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Service
{
    public class InsertProduct : IInsertProduct
    {
        public ProdutosDomain Execute(ProdutosDomain insProducts)
        {
            return DomainBase.Provider.GetService<IProductRepository>().InsertProdutos(insProducts);
        }
    }
}
