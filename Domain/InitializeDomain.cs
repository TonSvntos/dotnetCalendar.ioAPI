using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain
{
    public class InitializeDomain : IInitializeDomain
    {
        public void Initialize(ServiceProvider _provider)
        {
            if (DomainBase.Provider == null)
            {
                DomainBase.Provider = _provider;
            }
        }
    }
}
