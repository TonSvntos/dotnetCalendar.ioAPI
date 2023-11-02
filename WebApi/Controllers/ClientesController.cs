using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels;
using System;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders.Testing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : WebapiControllerBase
    {
        string errorMsg = string.Empty;


        [HttpGet]
        public IActionResult GetAllClients()
        {
            var result = new vmResult();

            try
            {

                var service = Provider.GetService<IClientesService>();


                var ret = service.GetAllClients();
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

        [HttpPost, Route("ListClientes")]
        public IActionResult ListClientes(vmClientes filter)
        {
            var result = new vmResult();

            try
            {
                
                var service = Provider.GetService<IClientesService>();

                filter.DataDoAtendimento = filter.DataDoAtendimento.Value.Date;//isso faz com que o horario sempre seja 00:00:00

                var ret = service.ListCliente(filter);
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
        [Route("AddCliente")]
        public IActionResult AddCliente(vmClientes insCliente)
        {
            var result = new vmResult();

            try
            {
                var service = Provider.GetService<IClientesService>();
                insCliente.DataDoAtendimento = insCliente.DataDoAtendimento.Value.Date;//isso faz com que o horario sempre seja 00:00:00



                bool isValid = Validate(insCliente);

                if (isValid)
                {
                    result.Data = service.InsertCliente(insCliente);
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
              

                result.FriendlyErrorMessage = "Erro inesperado";
                result.StackTrace = ex.Message + "/n" + ex.StackTrace;
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route("UpdateCliente")]
        public IActionResult UpdateCliente(vmClientes updCliente)
        {
            var result = new vmResult();

            try
            {
                var service = Provider.GetService<IClientesService>();
                updCliente.DataDoAtendimento = updCliente.DataDoAtendimento.Value.Date;//isso faz com que o horario sempre seja 00:00:00

                bool isValid = Validate(updCliente);

                

                if(isValid)
                {
                    result.Data = service.UpdateCliente(updCliente);

                    if (result.Data == null)
                    {
                         
                        result.FriendlyErrorMessage = "Cliente não encontrado";
                        return BadRequest(result);
                    }
                    return Accepted(result);
                }
                else
                {
                    result.FriendlyErrorMessage = errorMsg;
                    return BadRequest(result);
                }


            }
            catch (Exception ex)
            {

                result.FriendlyErrorMessage = "Erro inesperado";
                result.StackTrace = ex.Message + "/n" + ex.StackTrace;
                return BadRequest(result);
            }
        }

        private bool Validate(vmClientes cliente)
        {
            if (string.IsNullOrEmpty(cliente.NomeCliente) || cliente.NomeCliente.Length > 60)
            {
                errorMsg = "Por favor, insira um nome válido!";
                return false;
            }
            if (string.IsNullOrEmpty(cliente.ClienteBairro) || cliente.ClienteBairro.Length > 60)
            {
                errorMsg = "Por favor, insira um bairro válido!";
                return false;
            }
            if (string.IsNullOrEmpty(cliente.ClienteEndereco) || cliente.ClienteEndereco.Length > 60)
            {
                errorMsg = "Por favor, insira um endereco válido!";
                return false;
            }

            return true;
        }


    }
}
