using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.UseCasesPorts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderInputPort : IPort<CreateOrderDTO>
    {
    }
}
