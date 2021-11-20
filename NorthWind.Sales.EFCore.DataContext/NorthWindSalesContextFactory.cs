using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.EFCore.DataContext
{
    class NorthWindSalesContextFactory :
        IDesignTimeDbContextFactory<NorthWindSalesContext>
    {
        public NorthWindSalesContext CreateDbContext(string[] args)
        {
            var OptionsBuilder =
                new DbContextOptionsBuilder<NorthWindSalesContext>();
            OptionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;database=NetConf2021");
            return new NorthWindSalesContext(OptionsBuilder.Options);
        }
    }
}
