using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces;
using NorthWind.Sales.EFCore.DataContext;
using NorthWind.Sales.EFCore.Repositories;
using NorthWind.Sales.UseCases.Common.Interfaces;
using NorthWind.Sales.UseCases.CreateOrder;
using NorthWind.Sales.UseCasesPorts.CreateOrder;

namespace NorthWind.Sales.Repositories.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionEntry)
        {
            services.AddDbContext<NorthWindSalesContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString(connectionEntry)));

            services.AddScoped<IOrderWritableRepository,
                OrderWritableRepository>();
            services.AddScoped<ILogWritableRepository,
                LogWritableRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
