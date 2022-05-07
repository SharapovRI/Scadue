using Microsoft.Extensions.DependencyInjection;
using Scadue.Business.Interfaces;
using Scadue.Business.Services;

namespace Scadue.Extensions
{
    public static class ServiceProvider
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdministrativeUnitService, AdministrativeUnitService>();
            services.AddScoped<IUnitInfoService, UnitInfoService>();

            return services;
        }
    }
}
