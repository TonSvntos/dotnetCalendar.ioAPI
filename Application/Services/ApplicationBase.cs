using System;
using System.Collections.Generic;
using System.Text;
using Application;
using Domain;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public class ApplicationBase
    {
        public ServiceProvider Provider { get; private set; }

        public ApplicationBase()
        {
            var service = new ServiceCollection();

            //INICIALIZAÇÃO DOS CONTAINERS DE INJEÇÃO DE DEPENDENCIA
            service.AddDomainServiceCollection();



            // ****** Origem dos Dados *******

            // Dinamica (banco de dados, xml, json)
            //---------------------------------------------
            service.AddInfraServiceCollection();
            //---------------------------------------------

            //Mock (Dados Estáticos para teste)
            //---------------------------------------------

            //---------------------------------------------


            // ****** Origem dos Dados *******

            Provider = service.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            Provider.GetService<IInitializeDomain>().Initialize(Provider);
            return Provider.GetService<T>();
        }
    }
}
