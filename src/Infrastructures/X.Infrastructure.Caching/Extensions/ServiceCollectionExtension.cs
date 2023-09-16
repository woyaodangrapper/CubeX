using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace X.Infrastructure.Caching.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfraWindowDefault(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services.HasRegistered(nameof(WindowDefaultDependency)))
                return services;

            //if (!services.HasRegistered(nameof(MemoryCache)))
            //    services.AddMemoryCache();

            services.AddTransient<IWindowDefaultDependency, WindowDefaultDependency>();
            return services;
        }
    }
}