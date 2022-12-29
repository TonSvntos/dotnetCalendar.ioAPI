using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IUsuariosService, UsuariosService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IProductsService, ProductsService>();

            return services;
        }
    }
}