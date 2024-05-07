using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Application.ViewModels
{
    [Serializable]
    [DataContract]
    public class vmClientes
    {
        [DataMember]
        public long ClienteId { get; set; }
        [DataMember]
        public string NomeCliente { get; set; }
        [DataMember]
        public int? TelefoneCliente { get; set; }
        [DataMember]
        public string ClienteEndereco { get; set; }
        [DataMember]
        public DateTime? DataDoAtendimento { get; set; }
        [DataMember]
        public string ClienteBairro { get; set; }
        [DataMember]

        public string TipoDeServico { get; set; }
        [DataMember]
        public int? Numero { get; set; }
        [DataMember]
        public string Complemento { get; set; }
        [DataMember]
        public string Cidade { get; set; }
        [DataMember]
        public int? Cep { get; set; }
        [DataMember]
        public bool PagamentoConfirmado { get; set; }
        [DataMember]
        public double? Orcamento { get; set; }
        [DataMember]
        public double? Pagamento { get; set; }





    }
}
