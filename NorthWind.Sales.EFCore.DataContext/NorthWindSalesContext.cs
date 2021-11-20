using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.POCOs;
using NorthWind.Sales.Entities.POCOs;
using NorthWind.Sales.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.EFCore.DataContext
{
    public class NorthWindSalesContext : DbContext
    {
        public NorthWindSalesContext(
            DbContextOptions<NorthWindSalesContext> options) : base(options) { }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCity)
                .HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCountry)
                .HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipPostalCode)
                .HasMaxLength(10);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderID, od.ProductId });

        }
    }
}
