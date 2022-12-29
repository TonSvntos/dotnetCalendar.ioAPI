using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ProdutosDomain : CategoriasDomain
    {
        public long ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public double PrecoUnitario { get; set; }
        public int QuantidadeEstoque { get; set; }
        public bool Status { get; set; }
    }
}
