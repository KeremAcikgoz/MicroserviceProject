using OrderAPI.Models;
using OrderAPI.Models.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTests.OrderTestSetup
{
    public static class Orders
    {
        public static void AddOrders(this OrderDbContext context)
        {
            context.Orders.AddRange(
                    new OrderDTO
                    {
                        Price = 20.1,
                        Quantity = 1,
                        Status = "Preparing",
                        CustomerId = new Guid("7ebf2ba5-ba75-41f6-8104-a07600092990"),
                        ProductId = new Guid("d01deeb8-8197-4699-a534-9d1316640313"),
                        AddressId = new Guid("05668df6-dceb-43b9-b105-44ff05ea1cd0"),
                    },
                    new OrderDTO
                    {
                        Price = 15.99,
                        Quantity = 2,
                        Status = "Shipping",
                        CustomerId = new Guid("07668df6-dceb-43b9-b105-44ff05ea1cd0"),
                        ProductId = new Guid("5ae08d53-a870-404e-b3db-1a7e156f0881"),
                        AddressId = new Guid("7ebf8ba5-ba75-41f6-8104-a07600092990")
                    }
                );
        }
    }
}
