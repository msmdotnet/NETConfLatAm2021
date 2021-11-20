using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Sales.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly NorthWindSalesContext Context;
        readonly IApplicationStatusLogger Logger;
        public UnitOfWork(NorthWindSalesContext context,
            IApplicationStatusLogger logger) =>
            (Context, Logger) = (context, logger);

        public async ValueTask<int> SaveChanges()
        {
            int Result;
            try
            {
                Result = await Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Logger.Log(ex.InnerException?.Message ?? ex.Message);
                throw new UpdateException(
                    ex.InnerException?.Message ?? ex.Message,
                    ex.Entries.Select(
                        e => e.Entity.GetType().Name)
                    .ToList());
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new GeneralException(ex.Message);
            }
            return Result;
        }

    }

}
