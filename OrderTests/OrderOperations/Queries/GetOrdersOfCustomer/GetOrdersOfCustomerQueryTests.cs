using AutoMapper;
using FluentAssertions;
using Order.API.Clients;
using Order.API.OrderOperations.Queries.GetOrdersOfCustomer;
using OrderAPI.Models.DbOperations;
using OrderTests.OrderTestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTests.OrderOperations.Queries.GetOrdersOfCustomerQuery
{
    public class GetOrdersOfCustomerQueryTests : IClassFixture<OrderTestFixture>
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;
        private readonly CustomerClient _customerClient;

        public GetOrdersOfCustomerQueryTests(OrderTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
            _customerClient = testFixture.CustomerClient;
        }

        [Fact]
        public void WhenCustomerIsValid_OrderList_ShouldBeReturn()
        {
            //arrange
            var query = new GetOrdersOfaCustomerQuery(_context, _mapper, _customerClient);

            //act
            var orderList = query.Handle();

            //assert
            Assert.IsAssignableFrom<Task<List<OrdersOfCustomerViewModel>>>(orderList);
            Assert.NotNull(orderList);

        }


        [Fact]
        public void WhenCustomerIsNull_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var query = new GetOrdersOfaCustomerQuery(_context, _mapper, _customerClient);
            query.CustomerId = Guid.NewGuid();

            //act&assert

            FluentActions.Invoking(() => query.Handle()).Should().ThrowAsync<InvalidOperationException>();
                
        }


    }
}
