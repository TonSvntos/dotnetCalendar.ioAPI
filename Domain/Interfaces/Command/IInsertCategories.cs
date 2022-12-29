using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces.Command
{
    public interface IInsertCategories
    {
        public CategoriasDomain Execute(CategoriasDomain insCategories);
        
    }
}
