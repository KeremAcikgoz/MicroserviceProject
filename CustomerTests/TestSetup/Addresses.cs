using CustomerAPI.Models;
using CustomerAPI.Models.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTests.TestSetup
{
    public static class Addresses
    {
        public static void AddAddresses(this CustomerDbContext context)
        {
            context.Addresses.AddRange(
                        //new Address
                        //{
                        //    Id = new Guid("07668df6-dceb-43b9-b105-44ff05ea1cd0"),
                        //    Country = "Hungary",
                        //    City = "Budapest",
                        //    CityCode = 1234,
                        //},
                        //new Address
                        //{
                        //    Id = new Guid("7ebf8ba5-ba75-41f6-8104-a07600092990"),
                        //    Country = "Netherlands",
                        //    City = "Amsterdam",
                        //    CityCode = 4321,
                        //}
                );
        }
    }
}
