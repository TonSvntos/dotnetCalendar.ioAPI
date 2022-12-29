using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels;
using System;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : WebapiControllerBase
    {
        string errorMsg = string.Empty;


        [HttpPost, Route("ListProducts")]
        public IActionResult ListProducts(vmProductsFilter filter)
        {
            var result = new vmResult();

            try
            {
                if (filter.Page < 1 || filter.PageSize < 1)
                {
                    result.FriendlyErrorMessage = "Por favor, insira um número de página válido";
                    return BadRequest(result);
                }

                var service = Provider.GetService<IProductsService>();
                var ret = service.ListProduct(filter);
                result.Data = ret;
                if (ret.Count == 0)
                {
                    result.FriendlyErrorMessage = "Nenhuma informação encontrada.";
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.FriendlyErrorMessage = "Erro inesperado";
                result.StackTrace = ex.Message + "/n" + ex.StackTrace;
                return BadRequest(result);
            }
        }



        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(vmProducts insProduct)
        {
            var result = new vmResult();

            try
            {
                var service = Provider.GetService<IProductsService>();
                bool isValid = Validate(insProduct);

                if (isValid)
                {
                    result.Data = service.InsertProduct(insProduct);
                    return Ok(result);
                }
                else
                {
                    result.FriendlyErrorMessage = errorMsg;
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot insert duplicate key row in object"))
                {
                    result.FriendlyErrorMessage = "Produto já existe, por favor insira outro nome!";
                    return BadRequest(result);
                }

                result.FriendlyErrorMessage = "Erro inesperado";
                result.StackTrace = ex.Message + "/n" + ex.StackTrace;
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(vmProducts updProduct)
        {
            var result = new vmResult();

            try
            {
                var service = Provider.GetService<IProductsService>();
                bool isValid = Validate(updProduct);

                

                if(isValid)
                {
                    result.Data = service.UpdateProduct(updProduct);

                    if (result.Data == null)
                    {
                         
                        result.FriendlyErrorMessage = "Produto não encontrado";
                        return BadRequest(result);
                    }
                    return Ok(result);
                }
                else
                {
                    result.FriendlyErrorMessage = errorMsg;
                    return BadRequest(result);
                }


            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot insert duplicate key row in object"))
                {
                    result.FriendlyErrorMessage = "Produto já existe, por favor insira outro nome!";
                    return BadRequest(result);
                }

                result.FriendlyErrorMessage = "Erro inesperado";
                result.StackTrace = ex.Message + "/n" + ex.StackTrace;
                return BadRequest(result);
            }
        }


        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(long productId)
        {
            var result = new vmResult();

            try
            {
                var service = Provider.GetService<IProductsService>();
                var deleted = service.DeleteProduct(productId);

                if (!deleted)
                {
                    
                    result.FriendlyErrorMessage = "Produto não encontrado";
                    return BadRequest(result);
                }

                return Ok(result);
                
                

            }
            catch (Exception ex)
            {
                result.FriendlyErrorMessage = "Erro inesperado";
                result.StackTrace = ex.Message + "/n" + ex.StackTrace;
                return BadRequest(result);
            }
        }




        private bool Validate(vmProducts product)
        {
            if (string.IsNullOrEmpty(product.ProdutoNome) || product.ProdutoNome.Length > 60)
            {
                errorMsg = "Por favor, insira um nome válido!";
                return false;
            }
            if (product.QuantidadeEstoque < 0)
            {
                errorMsg = "Por favor, insira uma quantidade!";
                return false;
            }
            if (product.PrecoUnitario < 0)
            {
                errorMsg = "Por favor, insira um preço maior que 0!";
                return false;
            }
            
            return true;
        }


    }
}
