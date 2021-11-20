using Microsoft.Extensions.DependencyInjection;

namespace NorthWind.Sales.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddNorthWindSalesControllers(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderController,
                CreateOrderController>();
            return services;
        }
    }
}
