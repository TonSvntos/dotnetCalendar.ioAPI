using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces.Command
{
    public interface IListCategories
    {
        public List<CategoriasDomain> Execute();

    }
}
