using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.Command;
using Domain.Service;

namespace Domain
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServiceCollection(this IServiceCollection services)
        {
            services.AddSingleton<IInitializeDomain, InitializeDomain>();

            //User
            services.AddScoped<ILoginUser, LoginUser>();


            //Categories
            services.AddScoped<IListCategories, ListCategories>();
            services.AddScoped<IInsertCategories, InsertCategories>();


            services.AddScoped<IDeleteProduct, DeleteProduct>();
            services.AddScoped<IUpdateProduct, UpdateProduct>();
            services.AddScoped<IInsertProduct, InsertProduct>();
            services.AddScoped<IListProduct, ListProduct>();
            services.AddScoped<IListProductById, ListProductById>();






            //Products




            return services;
        }
    }
}
