using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Models.DbOperations
{
    public interface IOrderDbContext
    {
        
        DbSet<OrderDTO> Orders { get; set; }
        DbSet<Address> Addresses { get; set; }

        public DbSet<Product> Products { get; set; }
        int SaveChanges();
    }
}
