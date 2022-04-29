using Microsoft.Extensions.DependencyInjection;
using Scadue.Data.Interfaces;
using Scadue.Data.Repositories;

namespace Scadue.Extensions
{
    public static class RepositoriesProvider
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdministrativeUnitRepository, AdministrativeUnitRepository>();

            return services;
        }
    }
}
