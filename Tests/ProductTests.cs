using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models;
using Application.ViewModels;
using Application.Services;

using System.Collections.Generic;
using System;
using Framework.Infra;
using WebAPI.Controllers;

namespace Tests
{
    [TestClass]
    public class ProductTests
    {
        ProductsService service;



        [TestInitialize]
        public void Start()
        {
            service = new ProductsService();
        }

        [TestMethod]
        [TestCategory("NoException")]
        [Description("Verificar resultado da procedure de listagem dos produtos com filtro Bebidas")]
        [Owner("Antonio")]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void List(List<vmProducts> mockList)
        {
            vmProductsFilter filter = new vmProductsFilter();
            filter.Term = "bebida";
            filter.Page = 1;
            filter.PageSize = 10;
            var testLst = service.ListProduct(filter);


            for (int i = 0; i < mockList.Count; i++)
            {
                AssertAreEqual(mockList[i], testLst[i]);
            }
        }

        public static void AssertAreEqual(vmProducts expected, vmProducts actual)
        {
            Assert.AreEqual(expected.ProdutoId, actual.ProdutoId);
            Assert.AreEqual(expected.ProdutoNome, actual.ProdutoNome);
            Assert.AreEqual(expected.PrecoUnitario, actual.PrecoUnitario);
            Assert.AreEqual(expected.QuantidadeEstoque, actual.QuantidadeEstoque);
            Assert.AreEqual(expected.CategoriaId, actual.CategoriaId);
            Assert.AreEqual(expected.CategoriaNome, actual.CategoriaNome);
            Assert.AreEqual(expected.Status, actual.Status);
        }
        public static IEnumerable<object[]> GetTestData()
        {
            vmProducts item1 = new vmProducts
            {
                ProdutoId = 1,
                ProdutoNome = "Champagne",
                PrecoUnitario = 40,
                QuantidadeEstoque = 10,
                Status = false,
                CategoriaId = 1,
                CategoriaNome = "Bebidas"
            };
            vmProducts item2 = new vmProducts
            {
                ProdutoId = 2,
                ProdutoNome = "Vinho",
                PrecoUnitario = 60,
                QuantidadeEstoque = 15,
                Status = false,
                CategoriaId = 1,
                CategoriaNome = "Bebidas"
            };
            vmProducts item3 = new vmProducts
            {
                ProdutoId = 4,
                ProdutoNome = "Bebida Lactea",
                PrecoUnitario = 5,
                QuantidadeEstoque = 100,
                Status = false,
                CategoriaId = 3,
                CategoriaNome = "Laticinios"
            };

            yield return new object[] { new List<vmProducts>() { item1, item2, item3 } };
        }

        [TestMethod]
        [TestCategory("NoException")]
        [Description("Verificar resultado do método de inserir produtos")]
        [Owner("Antonio")]
        public void Insert( )
        {

            vmProducts mockProduct = new vmProducts
            {
                ProdutoId = 11,
                ProdutoNome = "Desinfetante",
                PrecoUnitario = 40,
                QuantidadeEstoque = 10,
                Status = false,
                CategoriaId = 2,
                CategoriaNome = "Produtos de Limpeza"
            };

            service.InsertProduct(mockProduct);

            var verifyProduct = service.ListProductById(mockProduct.ProdutoId);

            foreach (var item in verifyProduct)
            {
                AssertAreEqual(mockProduct, item);
            }

        }
       

        [TestMethod]
        [TestCategory("NoException")]
        [Description("Verificar resultado do método de atualizar produtos")]
        [Owner("Antonio")]
        public void Update( )
        {
            vmProducts mockProduct = new vmProducts
            {
                ProdutoId = 11,
                ProdutoNome = "Desinfetante",
                PrecoUnitario = 12,
                QuantidadeEstoque = 40,
                Status = false,
                CategoriaId = 2,
                CategoriaNome = "Produtos de Limpeza"

            };

            service.UpdateProduct(mockProduct);

            var verifyProduct = service.ListProductById(mockProduct.ProdutoId);

            foreach (var item in verifyProduct)
            {
                AssertAreEqual(mockProduct, item);
            }

        }

        

        [TestMethod]
        [TestCategory("NoException")]
        [Description("Verificar resultado do método de deletar produtos")]
        [Owner("Antonio")]
        public void Delete()
        {
            long productId = 10;

            service.DeleteProduct(productId);

            var verifyProduct = service.ListProductById(productId);

            Assert.IsTrue(verifyProduct.Count == 0);

        }

    }
}
