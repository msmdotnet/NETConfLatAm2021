using NorthWind.Sales.Entities.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCases.Common.Interfaces
{
    public interface IOrderWritableRepository
    {
        void CreateOrder(OrderAggregate order);
    }
}
