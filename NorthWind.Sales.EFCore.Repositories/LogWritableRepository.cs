using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOs;
using NorthWind.Sales.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.EFCore.Repositories
{
    public class LogWritableRepository : ILogWritableRepository
    {
        readonly NorthWindSalesContext Context;
        public LogWritableRepository(NorthWindSalesContext context) =>
            Context = context;
        public void Add(Log log)
        {
            Context.Add(log);
        }

        public void Add(string description)
        {
            Add(new Log(description));
        }
    }

}
