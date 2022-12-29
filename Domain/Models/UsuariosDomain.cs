using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class UsuariosDomain
    {
        public long UsuarioId { get; set; }
        public string Email { get; set; }
        public string UsuarioNome { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}
