using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.Command;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Service
{
    public class InsertCliente : IInsertCliente
    {
        public ClientesDomain Execute(ClientesDomain insClientes)
        {
            return DomainBase.Provider.GetService<IClienteRepository>().InsertCliente(insClientes);
        }
    }
}
