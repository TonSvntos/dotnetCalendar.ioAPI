using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.Command;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace Domain.Service
{
    public class LoginUser : ILoginUser
    {
        public UsuariosDomain Execute(LoginDomain login)
        {
            return DomainBase.Provider.GetService<ILoginRepository>().Login(login);
        }
    }
}
