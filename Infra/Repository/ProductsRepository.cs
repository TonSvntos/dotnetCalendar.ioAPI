using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Framework.Infra;
using Domain.Interfaces.Repository;

namespace Infra.Repository
{
    public class ProductsRepository : IProductRepository
    {
        const PEnvironment.PDB db = PEnvironment.PDB.ProjectsDatabase;

        public ProdutosDomain InsertProdutos(ProdutosDomain insProdutos)
        {
            Helper helper = new Helper();

            helper.ExecuteNonQuery(db, "dbo.spINSProduct", new
            {

                insProdutos.ProdutoNome,
                insProdutos.PrecoUnitario,
                insProdutos.QuantidadeEstoque,
                insProdutos.CategoriaId
            });

            return insProdutos;
        }

        public List<ProdutosDomain> ListProdutosDomain(ProductsFilterDomain filter)
        {
            Helper helper = new Helper();

            return helper.ExecuteList<ProdutosDomain>(db, "dbo.spLSTProdutos", new
            {
                filter.Term,
                filter.Page,
                filter.PageSize
            });
        }

        public List<ProdutosDomain> ListProdutosDomainById(long produtoId)
        {
            Helper helper = new Helper();

            return helper.ExecuteList<ProdutosDomain>(db, "dbo.spSELProductById", new
            {
                produtoId = produtoId
            });
        }

        public ProdutosDomain UpdateProdutos(ProdutosDomain updProdutos)
        {
            Helper helper = new Helper();

            helper.ExecuteNonQuery(db, "dbo.spUPDProdutos", new
            {
                updProdutos.ProdutoId,
                updProdutos.ProdutoNome,
                updProdutos.PrecoUnitario,
                updProdutos.QuantidadeEstoque
                
            });

            return updProdutos;
        }

        public long DeleteProduct(long idProduto)
        {
            Helper helper = new Helper();

            helper.ExecuteNonQuery(db, "dbo.spDELProduto", new
            {
                ProdutoId = idProduto
                
            });

            return idProduto;
        }

        
    }
}
