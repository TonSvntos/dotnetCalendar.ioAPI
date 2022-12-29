using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces.Command;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Interfaces
{
    public interface IProductsService
    {
        vmProducts InsertProduct(vmProducts insProduto);
        vmProducts UpdateProduct(vmProducts updProduto);
        List<vmProducts> ListProduct(vmProductsFilter filter);
        bool DeleteProduct(long dltProduct);

    }
}
