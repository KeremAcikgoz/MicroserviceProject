using AutoMapper;
using CustomerAPI.Models.DbOperations;
using CustomerTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Customer.API.CustomerOperations.Queries.GetCustomers;
using static Customer.API.CustomerOperations.Queries.GetCustomers.GetCustomersQuery;

namespace CustomerTests.CustomerOperations.Queries.GetCustomerQuery
{
    public class GetCustomerQueryTests : IClassFixture<TestFixture>
    {
        private readonly CustomerDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetCustomerQueryTests(TestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;

        }

        [Fact]
        public void CustomerList_ShouldBeReturn()
        {
            //arrange
            var query = new GetCustomersQuery(_dbContext, _mapper);

            //act
            var customerList = query.Handle();

            //assert
            Assert.IsAssignableFrom<List<CustomersViewModel>>(customerList);
            Assert.NotNull(customerList);

        }
    }
}
