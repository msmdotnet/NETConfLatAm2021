using NorthWind.Sales.Entities.POCOs;
using NorthWind.Sales.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Entities.Aggregates
{
    public class OrderAggregate : Order
    {
        readonly List<OrderDetail> OrderDetailsField = new List<OrderDetail>();
        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;

        // Si ya se agregó un ID de producto previamente, sumar la cantidad
        public void AddDetail(OrderDetail orderDetail)
        {
            var ExistingOrderDetail =
                OrderDetailsField.FirstOrDefault(
                    o => o.ProductId == orderDetail.ProductId);
            if (ExistingOrderDetail != null)
            {
                ExistingOrderDetail.Quantity += orderDetail.Quantity;
            }
            else
            {
                OrderDetailsField.Add(orderDetail);
            }
        }

        public void AddDetail(int productId, decimal unitPrice, short quantity) =>
            AddDetail(new OrderDetail
            {
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = quantity
            });
    }

}
