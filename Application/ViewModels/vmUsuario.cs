using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Application.ViewModels
{
    [Serializable]
    [DataContract]
    public class vmUsuario
    {
        [DataMember]
        public long UsuarioId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string UsuarioNome { get; set; }
        [DataMember]
        public string Senha { get; set; }
        [DataMember]
        public string token { get; set; }
    }
}
