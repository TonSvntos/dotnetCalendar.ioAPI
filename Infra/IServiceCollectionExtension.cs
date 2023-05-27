using Microsoft.Extensions.DependencyInjection;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.Repository;
using Infra.Repository;

namespace Infra.Context
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfraServiceCollection(this IServiceCollection services)
        {
            
            services.AddScoped<IClienteRepository, ClientesRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();



            //return services;
            return null;
        }
    }
    
}
