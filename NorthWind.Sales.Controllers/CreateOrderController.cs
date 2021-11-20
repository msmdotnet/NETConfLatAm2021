using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.Presenters;
using NorthWind.Sales.UseCasesPorts.CreateOrder;
using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Controllers
{
    public class CreateOrderController : ICreateOrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutputPort;

        public CreateOrderController(ICreateOrderInputPort inputPort, 
            ICreateOrderOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        public async ValueTask<CreateOrderViewModel> CreateOrder(
            CreateOrderDTO order)
        {
            await InputPort.Handle(order);
            return ((IPresenter<CreateOrderViewModel>)OutputPort).Content;
        }
    }
}
