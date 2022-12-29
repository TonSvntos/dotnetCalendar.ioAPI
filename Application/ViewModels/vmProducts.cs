using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Application.ViewModels
{
    [Serializable]
    [DataContract]
    public class vmProducts : vmCategorias
    {
        [DataMember]
        public long ProdutoId { get; set; }
        [DataMember]
        public string ProdutoNome { get; set; }
        [DataMember]
        public double PrecoUnitario { get; set; }
        [DataMember]
        public int QuantidadeEstoque { get; set; }
        [DataMember]
        public bool Status { get; set; }
    }
}
