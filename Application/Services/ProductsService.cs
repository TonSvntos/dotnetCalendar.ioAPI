using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces.Command;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public class ProductsService : ApplicationBase,IProductsService
    {
        public vmProducts InsertProduct(vmProducts insProduto)
        {
            var rep = GetService<IInsertProduct>();

            ProdutosDomain param = DataHelper.Read<ProdutosDomain>(insProduto);

            var item = rep.Execute(param);

            var result = ConvertToViewModel(item);

            return result;
        }

        public vmProducts UpdateProduct(vmProducts updProduto)
        {

            var verifyId = ListProductById(updProduto.ProdutoId);

            if (verifyId.Count == 0)
            {
                return null;
            }

            var rep = GetService<IUpdateProduct>();

            ProdutosDomain param = DataHelper.Read<ProdutosDomain>(updProduto);

            var item = rep.Execute(param);

            var result = ConvertToViewModel(item);

            return result;
        }

        public List<vmProducts> ListProduct(vmProductsFilter filter)
        {
            ProductsFilterDomain param = DataHelper.Read<ProductsFilterDomain>(filter);

            var rep = GetService<IListProduct>();

            List<ProdutosDomain> lstProducts = rep.Execute(param);

            return ConvertModelToViewModel(lstProducts);

        }

        public bool DeleteProduct(long dltProduct)
        {
            var verifyId = ListProductById(dltProduct);

            if (verifyId.Count == 0)
            {
                return false;
            }
           
            var rep = GetService<IDeleteProduct>();
            rep.Execute(dltProduct);

            return true;
        }

        public List<vmProducts> ListProductById(long produtoId)
        {
            var rep = GetService<IListProductById>();

            List<ProdutosDomain> lstProduct = rep.Execute(produtoId);

            return ConvertModelToViewModel(lstProduct);

        }

        private List<vmProducts> ConvertModelToViewModel(List<ProdutosDomain> domainModelList)
        {
            var _list = DataHelper.List<vmProducts>(domainModelList);
            return _list;
        }


        private vmProducts ConvertToViewModel(ProdutosDomain d)
        {
            var item = new vmProducts
            {
                ProdutoId = d.ProdutoId,
                ProdutoNome = d.ProdutoNome,
                PrecoUnitario = d.PrecoUnitario,
                QuantidadeEstoque = d.QuantidadeEstoque,
                Status = d.Status,
                CategoriaId = d.CategoriaId

            };
            return item;
        }
    }
}

