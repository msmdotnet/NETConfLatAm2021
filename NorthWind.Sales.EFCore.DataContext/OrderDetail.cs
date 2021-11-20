using NorthWind.Sales.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.EFCore.DataContext
{
    public class OrderDetail : Entities.ValueObjects.OrderDetail
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
