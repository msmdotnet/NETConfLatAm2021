using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Entities.ValueObjects
{
    public class OrderDetail
    {
        public int ProductId { get; init; }
        public decimal UnitPrice { get; init; }
        public short Quantity { get; set; }

    }
}
