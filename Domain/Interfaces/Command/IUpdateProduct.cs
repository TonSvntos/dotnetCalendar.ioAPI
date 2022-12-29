using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;


namespace Domain.Interfaces.Command
{
    public interface IUpdateProduct
    {
        public ProdutosDomain Execute(ProdutosDomain updProduct);

    }
}
