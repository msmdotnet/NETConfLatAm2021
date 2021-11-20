using NorthWind.Sales.UseCasesPorts.CreateOrder;
using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Presenters
{
    public class CreateOrderPresenter : ICreateOrderOutputPort,
        IPresenter<CreateOrderViewModel>
    {
        public CreateOrderViewModel Content
        {
            get; private set;
        } 

        public ValueTask Handle(int orderId)
        {
            Content = new CreateOrderViewModel(orderId);
            return ValueTask.CompletedTask;
        }
    }
}
