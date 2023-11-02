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
        List<vmClientes> GetAllClients();

        vmClientes UpdateCliente(vmClientes updCliente);
        List<vmClientes> ListCliente(vmClientes filter);

    }
}
