using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repository
{
    public interface ICategoriesRepository
    {
        List<CategoriasDomain> ListCategoriesDomain();
        CategoriasDomain InsertCategories(CategoriasDomain insCategorias);
    }
}
