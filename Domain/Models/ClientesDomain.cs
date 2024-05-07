using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Models
{
    public class ClientesDomain
    {

        public long ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public int? TelefoneCliente { get; set ; }
        public string ClienteEndereco { get; set; }
        public DateTime DataDoAtendimento { get; set; }
        public string ClienteBairro { get; set; }
        public string TipoDeServico { get; set; }
        public int? Cep { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public bool PagamentoConfirmado { get; set; }
        public double? Orcamento { get; set; }
        public double? Pagamento { get; set; }





    }
}
