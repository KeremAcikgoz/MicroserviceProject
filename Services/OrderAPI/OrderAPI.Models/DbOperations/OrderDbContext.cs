using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAPI.Models;
using System.Threading.Tasks;
using Customer.API.Common;

namespace OrderAPI.Models.DbOperations
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        { }

        public DbSet<OrderDTO> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is CreatedUpdated && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((CreatedUpdated)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((CreatedUpdated)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
