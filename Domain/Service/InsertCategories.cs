using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.Command;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Service
{
    public class InsertCategories : IInsertCategories
    {
        public CategoriasDomain Execute(CategoriasDomain insCategories)
        {
            return DomainBase.Provider.GetService<ICategoriesRepository>().InsertCategories(insCategories);
        }
    }
}
