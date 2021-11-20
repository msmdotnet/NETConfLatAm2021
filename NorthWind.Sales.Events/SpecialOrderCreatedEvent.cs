using NorthWind.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Events
{
    public class SpecialOrderCreatedEvent : IEvent
    {
        public int OrderId { get; }
        public int ProductsCount { get; }

        public SpecialOrderCreatedEvent(int orderId, int productsCount)
        {
            OrderId = orderId;
            ProductsCount = productsCount;
        }
    }
}
