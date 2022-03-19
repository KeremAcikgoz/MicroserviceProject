using Customer.API.CustomerOperations.Commands.CreateCustomer;
using CustomerAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTests.TestSetup
{
    public class CustomerClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new CreateCustomerModel
                {
                    Name = "",
                    Email = "testemail",
                    Address = new Address
                    {
                        Id = new Guid("a072689a-94d0-4bff-a3b6-d35324c0a7c7"),
                        City= "testcity",
                        Country = "testcountry",
                        CityCode = 12312
                    }
                }
            };
            yield return new object[]
            {
                new CreateCustomerModel
                {
                    Name = "sss",
                    Email = "",
                    Address = new Address
                    {
                        Id = new Guid("a072689a-94d0-4bff-a3b6-d35324c0a7c7"),
                        City= "testcity",
                        Country = "testcountry",
                        CityCode = 12312
                    }
                }
            };

            yield return new object[]
            {
                new CreateCustomerModel
                {
                    Name = "",
                    Email = "",
                    Address = new Address
                    {
                        Id = new Guid("a072689a-94d0-4bff-a3b6-d35324c0a7c7"),
                        City= "testcity",
                        Country = "testcountry",
                        CityCode = 12312
                    }
                }
            };
            yield return new object[]
            {
                new CreateCustomerModel
                {
                    Name = "kerem",
                    Email = "eee",
                    Address = new Address
                    {
                        City = "",
                        Country = "dd",
                        CityCode = 1
                    }
                }
            };
            yield return new object[]
            {
                new CreateCustomerModel
                {
                    Name = "kerem",
                    Email = "eee",
                    Address = new Address
                    {
                        City = "ss",
                        Country = "",
                        CityCode = 1
                    }
                }
            };

            yield return new object[]
            {
                new CreateCustomerModel
                {
                    Name = "kerem",
                    Email = "eee",
                    Address = new Address
                    {
                        City = "ss",
                        Country = "ss",
                        CityCode = 0
                    }
                }
            };

            yield return new object[]
            {
                new CreateCustomerModel
                {
                    Name = "kerem",
                    Email = "eee",
                    Address = new Address
                    {
                        City = "ss",
                        Country = "",
                        CityCode = 0
                    }
                }
            };
            yield return new object[]
            {
                new CreateCustomerModel
                {
                    Name = "kerem",
                    Email = "eee",
                    Address = new Address
                    {
                        City = "",
                        Country = "ss",
                        CityCode = 0
                    }
                }
            };

            yield return new object[]
            {
                new CreateCustomerModel
                {
                    Name = "kerem",
                    Email = "eee",
                    Address = new Address
                    {
                        City = "",
                        Country = "",
                        CityCode = 0
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
