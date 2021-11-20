using Microsoft.AspNetCore.Mvc;
using NorthWind.Sales.Controllers;
using NorthWind.Sales.DTOs.CreateOrder;

namespace NorthWind.Sales.WebApiControllers
{
    [Route("api/order")]
    [ApiController]
    public class CreateOrderController : ControllerBase
    {
        readonly ICreateOrderController Controller;

        public CreateOrderController(ICreateOrderController controller)
        {
            Controller = controller;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO order)
        {
            var CreateOrderViewModel =
                await Controller.CreateOrder(order);
            return Ok(CreateOrderViewModel.OrderId);
        }


    }
}