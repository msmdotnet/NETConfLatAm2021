using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.UseCases.CreateOrder;
using NorthWind.Sales.UseCasesPorts.CreateOrder;

namespace NorthWind.Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
            this IServiceCollection services)
        {
            services.AddTransient<ICreateOrderInputPort,
                CreateOrderInteractor>();
            return services;
        }
    }
}
