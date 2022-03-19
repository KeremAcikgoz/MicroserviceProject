using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Models.DbOperations
{
    public class OrderDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OrderDbContext(serviceProvider.GetRequiredService<DbContextOptions<OrderDbContext>>()))
            {
                if (context.Orders.Any())
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
                context.Products.AddRange(
                        new Product
                        {
                            Id = new Guid("d05deeb8-8197-4699-a534-9d1316640313"),
                            Name = "Camera",
                            ImageUrl = "Camera.com",
                        },
                        new Product
                        {
                            Id = new Guid("5ae08d53-a870-404e-b3db-1a7e156f0881"),
                            Name = "Laptop",
                            ImageUrl = "Laptop.com"
                        },
                        new Product
                        {
                            Id = new Guid("cc798f8d-6ceb-4f8c-9431-25f3769c8ad3"),
                            Name = "Television",
                            ImageUrl = "Television.com"
                        }
                    );

                //context.Orders.AddRange(
                //        new OrderDTO
                //        {
                //            Price = 20.1,
                //            Quantity = 1,
                //            Status = "Preparing",
                //            CustomerId = new Guid("7ebf8ba5-ba75-41f6-8104-a07600092990"),
                //            ProductId = new Guid("d05deeb8-8197-4699-a534-9d1316640313"),
                //            AddressId = new Guid("08668df6-dceb-43b9-b105-44ff05ea1cd0"),
                //        },
                //        new OrderDTO
                //        {
                //            Price = 15.99,
                //            Quantity = 2,
                //            Status = "Shipping",
                //            CustomerId = new Guid("08668df6-dceb-43b9-b105-44ff05ea1cd0"),
                //            ProductId = new Guid("5ae08d53-a870-404e-b3db-1a7e156f0881"),
                //            AddressId = new Guid("7ebf8ba5-ba75-41f6-8104-a07600092990")
                //        }
                //    );
                context.SaveChanges();
            }
        }
    }
}
