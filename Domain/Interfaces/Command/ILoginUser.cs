using Domain.Models;

namespace Domain.Interfaces.Command
{
    public interface ILoginUser
    {
        public UsuariosDomain Execute(LoginDomain login);

    }
}
