﻿using System.Collections.Generic;
using Domain.Models;


namespace Domain.Interfaces.Command
{
    public interface IListCliente
    {
        public List<ClientesDomain> Execute(ClientesDomain filter);
        public List<ClientesDomain> GetAllClients();

        public List<ClientesDomain> ListOrcaments();



    }
}
