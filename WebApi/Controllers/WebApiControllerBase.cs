using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Application;


namespace WebAPI.Controllers
{
    public class WebapiControllerBase : ControllerBase
    {
        public ServiceProvider Provider { get; private set; }

        public WebapiControllerBase()
        {
            var service = new ServiceCollection();
            service.AddApplicationServiceCollection();

            Provider = service.BuildServiceProvider();
        }


    }
}