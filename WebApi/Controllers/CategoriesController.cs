using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infra.Context;
using Application.Interfaces;
using Application.ViewModels;
using WebAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : WebapiControllerBase
    {
        
        [HttpGet, Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var result = new vmResult();

            try
            {
                var service = Provider.GetService<ICategoriesService>();
                var ret = service.ListAllCategories();
                result.Data = ret;
                if (ret.Count == 0)
                {
                    result.FriendlyErrorMessage = "No records found.";
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
        [Route("AddCategory")]
        public IActionResult AddCategory(vmCategorias insCategories)
        {
            var result = new vmResult();

            try
            {
                var service = Provider.GetService<ICategoriesService>();
                if (string.IsNullOrEmpty(insCategories.CategoriaNome) || insCategories.CategoriaNome.Length > 60)
                {
                    result.FriendlyErrorMessage = "Por favor, insira um nome válido!";
                    return BadRequest(result);
                }
                result.Data = service.InsertCategory(insCategories);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("Cannot insert duplicate key row in object"))
                {
                    result.FriendlyErrorMessage = "Categoria já existe, por favor insira outro nome!";
                    return BadRequest(result);
                }

                result.FriendlyErrorMessage = "Erro inesperado";
                result.StackTrace = ex.Message + "/n" + ex.StackTrace;
                return BadRequest(result);
            }
        }
    }
}
