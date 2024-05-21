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
    public interface IClientesService
    {
        vmClientes InsertCliente(vmClientes insCliente);
        public void ConfirmPayment(vmClientes clientes);
        List<vmClientes> GetAllClients();

        vwReturnFiles GenerateExcel(List<Meses> meses);


        vmClientes UpdateCliente(vmClientes updCliente);
        List<vmClientes> ListCliente(vmClientes filter);
        public List<vmClientes> ListOrcamentos();

    }
}
