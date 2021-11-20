using NorthWind.Sales.EFCore.DataContext;
using NorthWind.Sales.Entities.Aggregates;
using NorthWind.Sales.UseCases.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.EFCore.Repositories
{
    public class OrderWritableRepository : IOrderWritableRepository
    {
        readonly NorthWindSalesContext Context;
        public OrderWritableRepository(NorthWindSalesContext context) =>
            Context = context;

        public void CreateOrder(OrderAggregate order)
        {
            Context.Add(order);

            foreach (var Item in order.OrderDetails)
            {
                Context.Add(new DataContext.OrderDetail
                {
                    ProductId = Item.ProductId,
                    UnitPrice = Item.UnitPrice,
                    Quantity = Item.Quantity,
                    Order = order
                });
            }
        }

    }
}
