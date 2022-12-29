using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Interfaces.Command
{
    public interface IDeleteProduct
    {
        void Execute(long dltProduct);

    }
}
