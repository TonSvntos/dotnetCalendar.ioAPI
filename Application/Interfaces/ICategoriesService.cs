using System;
using System.Collections.Generic;
using System.Text;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ICategoriesService
    {
        List<vmCategorias> ListAllCategories();
        vmCategorias InsertCategory(vmCategorias insVoyageMaintenance);
    }
}
