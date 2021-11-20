using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces;

namespace NorthWind.Loggers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLoggers(
            this IServiceCollection services)
        {
            services.AddScoped<IApplicationStatusLogger,
                DebugStatusLogger>();
            return services;
        }
    }
}
