
using System.Collections.Generic;
using Domain.Models;


namespace Domain.Interfaces.Command
{
    public interface IListClienteById
    {
        public List<ClientesDomain> Execute(long ClienteId);

    }
}
