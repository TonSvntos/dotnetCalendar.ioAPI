using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        public List<ProdutosDomain> ListProdutosDomain(ProductsFilterDomain filter);
        public List<ProdutosDomain> ListProdutosDomainById(long produtoId);

        public ProdutosDomain UpdateProdutos(ProdutosDomain updProdutos);
        public ProdutosDomain InsertProdutos(ProdutosDomain insProdutos);
        long DeleteProduct(long idProduto);



    }
}
