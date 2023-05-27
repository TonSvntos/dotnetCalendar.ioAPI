using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;


namespace Domain.Interfaces.Command
{
    public interface IUpdateCliente
    {
        public ClientesDomain Execute(ClientesDomain updCliente);

    }
}
