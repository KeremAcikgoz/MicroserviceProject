using AutoMapper;
using Order.API.OrderOperations.Queries;
using OrderAPI.Models.DbOperations;
using OrderTests.OrderTestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTests.OrderOperations.Queries.GetOrders
{
    public class GetOrderQueryTests : IClassFixture<OrderTestFixture>
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderQueryTests(OrderTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void OrderList_ShouldBeReturn()
        {
            //arrange
            var query = new GetOrderQuery(_context, _mapper);


            //act
            var orderList = query.Handle();

            //assert
            Assert.IsAssignableFrom<List<OrdersViewModel>>(orderList);
            Assert.NotNull(orderList);
        }
    }
}
