using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces;

namespace NorthWind.Mail
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMailService(
            this IServiceCollection services)
        {
            services.AddTransient<IMailService,
                MailService>();
            return services;
        }
    }
}
