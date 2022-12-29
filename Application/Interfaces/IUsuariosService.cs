using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IUsuariosService
    {
        vmUsuario DoLogin(vmLogin login);
    }
}

