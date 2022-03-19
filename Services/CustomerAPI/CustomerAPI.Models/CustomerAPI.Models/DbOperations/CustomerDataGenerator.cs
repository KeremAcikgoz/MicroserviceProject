using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerAPI.Models.DbOperations
{
    public class CustomerDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerDbContext(serviceProvider.GetRequiredService<DbContextOptions<CustomerDbContext>>()))
            {
                if (context.Customers.Any())
                {
                    return;
                }
                context.Addresses.AddRange(
                        new Address
                        {
                            Id = new Guid("08668df6-dceb-43b9-b105-44ff05ea1cd0"),
                            Country = "Hungary",
                            City = "Budapest",
                            CityCode = 1234,
                        },
                        new Address
                        {
                            Id = new Guid("7ebf8ba5-ba75-41f6-8104-a07600092990"),
                            Country = "Netherlands",
                            City = "Amsterdam",
                            CityCode = 4321,
                        }
                    );

                context.Customers.AddRange(
                        new CustomerDTO
                        {
                            Name = "Attila Szalai",
                            Email = "attila@mail.com",
                            //Address = 
                            //    new Address
                            //    {
                            //        Country = "Hungary",
                            //        City = "Budapest",
                            //        CityCode = 1234,
                            //    }
                            AddressId = new Guid("08668df6-dceb-43b9-b105-44ff05ea1cd0"),
                        },
                        new CustomerDTO
                        {
                            Name = "Ferdi Kadıoğlu",
                            Email = "ferdi@mail.com",
                            //Address =
                            //    new Address
                            //    {
                            //        Country = "Netherlands",
                            //        City = "Amsterdam",
                            //        CityCode = 4312

                            //    }
                            AddressId = new Guid("7ebf8ba5-ba75-41f6-8104-a07600092990")
                        }
                    );
                context.SaveChanges();
            }
        }
    }
}
