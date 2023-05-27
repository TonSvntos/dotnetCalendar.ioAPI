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


            services.AddScoped<IUpdateCliente, UpdateCliente>();
            services.AddScoped<IInsertCliente, InsertCliente>();
            services.AddScoped<IListCliente, ListCliente>();
            services.AddScoped<IListClienteById, ListClienteById>();






            //Clientes




            return services;
        }
    }
}
