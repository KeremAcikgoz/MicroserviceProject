using CustomerAPI.Models;
using CustomerAPI.Models.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTests.TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this CustomerDbContext context)
        {
            context.Customers.AddRange(
                    new CustomerDTO
                    {
                        Name = "Attila Szalai",
                        Email = "attila@mail.com",
                        AddressId = new Guid("07668df6-dceb-43b9-b105-44ff05ea1cd0"),
                    },
                    new CustomerDTO
                    {
                        Name = "Ferdi Kadıoğlu",
                        Email = "ferdi@mail.com",
                        AddressId = new Guid("7ebf8ba5-ba75-41f6-8104-a07600092990")
                    }
                );
        }
    }
}
