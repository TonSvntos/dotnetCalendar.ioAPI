using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Domain
{
    public class DomainBase
    {
        //lazy -> determina modelos de entidade carregadas sob demanda. i.e. linq (first, find, single, find, ToList, foreach)
        private static readonly Lazy<DomainBase> lazy = new Lazy<DomainBase>(() => new DomainBase());

        public static DomainBase Instance { get { return lazy.Value; } }

        public static IConfiguration Config { get; set; }

        public static ServiceProvider Provider { get; set; }
       

        public DomainBase()
        {
            RepositoryBase();
        }

        public static void RepositoryBase()
        {
            var builder = new ConfigurationBuilder();
              //.SetBasePath(Directory.GetCurrentDirectory())
              //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Config = builder.Build();
        }

      
    }
}
