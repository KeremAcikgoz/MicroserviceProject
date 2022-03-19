using CustomerAPI.Models;
using Order.API.OrderOperations.CreateOrder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTests.OrderTestSetup
{
    public class OrderClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new CreateOrderViewModel
                {
                    CustomerId = new Guid("6131c4b4-7c46-4316-828f-e1604b83cc3a"),
                    ProductId = new Guid("78861146-d3dc-4bfb-8dec-869791f8e92c"),
                    Status = "",
                    Price = 5.90,
                    Quantity = 1,
                    Address = new Address
                    {
                        City = "newcity",
                        Country = "newcountry",
                        CityCode = 2,
                        Id = new Guid("f94dce67-8314-454b-9727-61567889f379"),
                    }
                }
            };

            yield return new object[]
            {
                new CreateOrderViewModel
                {
                    CustomerId = new Guid("6131c4b4-7c46-4316-828f-e1604b83cc3a"),
                    ProductId = new Guid("78861146-d3dc-4bfb-8dec-869791f8e92c"),
                    Status = "",
                    Price = 0,
                    Quantity = 0,
                    Address = new Address
                    {
                        City = "newcity",
                        Country = "newcountry",
                        CityCode = 2,
                        Id = new Guid("f94dce67-8314-454b-9727-61567889f379"),
                    }
                }
            };

            yield return new object[]
            {
                new CreateOrderViewModel
                {
                    CustomerId = new Guid("6131c4b4-7c46-4316-828f-e1604b83cc3a"),
                    ProductId = new Guid("78861146-d3dc-4bfb-8dec-869791f8e92c"),
                    Status = "sss",
                    Price = 3.10,
                    Quantity = 0,
                    Address = new Address
                    {
                        City = "newcity",
                        Country = "newcountry",
                        CityCode = 2,
                        Id = new Guid("f94dce67-8314-454b-9727-61567889f379"),
                    }
                }
            };

            yield return new object[]
            {
                new CreateOrderViewModel
                {
                    CustomerId = new Guid("6131c4b4-7c46-4316-828f-e1604b83cc3a"),
                    ProductId = new Guid("78861146-d3dc-4bfb-8dec-869791f8e92c"),
                    Status = "",
                    Price = 0,
                    Quantity = 0,
                    Address = new Address
                    {
                        City = "newcity",
                        Country = "newcountry",
                        CityCode = 2,
                        Id = new Guid("f94dce67-8314-454b-9727-61567889f379"),
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
