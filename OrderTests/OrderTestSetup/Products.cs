using OrderAPI.Models;
using OrderAPI.Models.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTests.OrderTestSetup
{
    public static class Products
    {
        public static void AddProducts(this OrderDbContext context)
        {
            context.Products.AddRange(
                        //new Product
                        //{
                        //    Id = new Guid("d05deeb8-8197-4699-a534-9d1316640313"),
                        //    Name = "Camera",
                        //    ImageUrl = "Camera.com",
                        //},
                        //new Product
                        //{
                        //    Id = new Guid("5ae08d53-a870-404e-b3db-1a7e156f0881"),
                        //    Name = "Laptop",
                        //    ImageUrl = "Laptop.com"
                        //},
                        //new Product
                        //{
                        //    Id = new Guid("cc798f8d-6ceb-4f8c-9431-25f3769c8ad3"),
                        //    Name = "Television",
                        //    ImageUrl = "Television.com"
                        //}
                );
        }
    }
}
