using Microsoft.Extensions.DependencyInjection;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Interfaces;
using Scadue.Recipient.OpenStreetMap.OverpassAPI.Recipients;

namespace Scadue.Extensions
{
    public static class RecipientsProvider
    {
        public static IServiceCollection AddRecipients(this IServiceCollection services)
        {
            services.AddScoped<IAdministrativeUnitRecipient, AdministrativeUnitRecipient>();

            return services;
        }
    }
}
