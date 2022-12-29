using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces.Repository
{
    public interface ILoginRepository
    {
        public UsuariosDomain Login(LoginDomain user);


    }
}
