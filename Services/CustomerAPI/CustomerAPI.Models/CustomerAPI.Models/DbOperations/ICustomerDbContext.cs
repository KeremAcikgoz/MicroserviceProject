using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Models.DbOperations
{
    public interface ICustomerDbContext
    {
        DbSet<CustomerDTO> Customers { get; set; }
        DbSet<Address> Addresses { get; set; }  

        int SaveChanges();
    }
}
