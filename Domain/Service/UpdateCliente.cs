using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Domain.Interfaces.Command;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Repository;

namespace Domain.Service
{
    internal class UpdateCliente : IUpdateCliente
    {
        public ClientesDomain Execute(ClientesDomain updProduct)
        {
            return DomainBase.Provider.GetService<IClienteRepository>().UpdateCliente(updProduct);
        }

        public void ConfirmPayment(ClientesDomain updProduct)
        {
            DomainBase.Provider.GetService<IClienteRepository>().ConfirmPayment(updProduct);

        }
    }
}
