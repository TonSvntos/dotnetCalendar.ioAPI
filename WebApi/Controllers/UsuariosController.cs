using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : WebapiControllerBase
{
    string errorMsg = string.Empty;

    [HttpPost]
    [Route("Login")]
    public IActionResult Login(vmLogin user)
    {
        var result = new vmResult();

        try
        {
            var service = Provider.GetService<IUsuariosService>();
            result.Data = service.DoLogin(user);

            if (result.Data == null)
            {
                result.FriendlyErrorMessage = "Usuario não encontrado";
                return BadRequest(result);
            }
            return Ok();



        }
        catch (Exception ex)
        {

            result.FriendlyErrorMessage = "Erro inesperado";
            result.StackTrace = ex.Message + "/n" + ex.StackTrace;
            return BadRequest(result);
        }
    }
}

