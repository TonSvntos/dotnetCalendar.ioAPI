using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Domain.Interfaces.Command;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Repository;

namespace Domain.Service
{
    public class ListCategories : IListCategories
    {
        public List<CategoriasDomain> Execute()
        {
            return DomainBase.Provider.GetService<ICategoriesRepository>().ListCategoriesDomain();
        }
    }
}
