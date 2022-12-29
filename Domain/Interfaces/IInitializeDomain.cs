using Microsoft.Extensions.DependencyInjection;

namespace Domain.Interfaces
{
    public interface IInitializeDomain
    {
        void Initialize(ServiceProvider _provider);
    }
}
