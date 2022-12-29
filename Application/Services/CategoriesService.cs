using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces.Command;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public class CategoriesService : ApplicationBase,ICategoriesService
    {
        public vmCategorias InsertCategory(vmCategorias insCategories)
        {
            var rep = GetService<IInsertCategories>();

            CategoriasDomain param = DataHelper.Read<CategoriasDomain>(insCategories);

            var item = rep.Execute(param);

            var result = ConvertToViewModel(item);

            return result;
        }

        public List<vmCategorias> ListAllCategories()
        {
            var rep = GetService<IListCategories>();

            //VoyageMaintenanceFilterDomain param = DataHelper.Read<VoyageMaintenanceFilterDomain>(filter);

            List<CategoriasDomain> lstCategories = rep.Execute();

            return ConvertModelToViewModel(lstCategories);

        }


        private List<vmCategorias> ConvertModelToViewModel(List<CategoriasDomain> domainModelList)
        {
            var _list = DataHelper.List<vmCategorias>(domainModelList);
            return _list;
        }


        private vmCategorias ConvertToViewModel(CategoriasDomain d)
        {
            var item = new vmCategorias
            {
                CategoriaId = d.CategoriaId,
                CategoriaNome = d.CategoriaNome,
                
            };
            return item;
        }
    }
}
