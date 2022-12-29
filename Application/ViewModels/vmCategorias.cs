using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.ViewModels
{
    [Serializable]
    [DataContract]
    public class vmCategorias
    {
        [DataMember]
        public long CategoriaId { get; set; }
        [DataMember]
        public string CategoriaNome { get; set; }
    }
}
