using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Validators;
using NorthWind.Sales.DTOs.CreateOrder;

namespace NorthWind.Sales.DTOs
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDTOValidators(
            this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateOrderDTO>,
                CreateOrderDTOValidator>();
            return services;
        }
    }
}
