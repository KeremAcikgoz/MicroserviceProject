using CustomerAPI.Infrastructure;
using CustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerDTO GetCustomerById(Guid Id)
        {
            return new CustomerDTO()
            {
                Id = Id,
                Name = "Attila",
                Email = "Szalai",
                Address =
                    new Address
                    {
                        Country = "Hungary",
                        City = "Budapest",
                        CityCode = 1234,
                    }
            };
        }
    }
}
