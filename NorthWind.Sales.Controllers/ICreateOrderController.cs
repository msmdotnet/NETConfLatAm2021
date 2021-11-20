using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.ViewModels;

namespace NorthWind.Sales.Controllers
{
    public interface ICreateOrderController
    {
        ValueTask<CreateOrderViewModel> CreateOrder(
            CreateOrderDTO order);
    }
}