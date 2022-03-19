using AutoMapper;
using FluentAssertions;
using Order.API.OrderOperations.Queries;
using OrderAPI.Models.DbOperations;
using OrderTests.OrderTestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTests.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryTests : IClassFixture<OrderTestFixture>
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryTests(OrderTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenOrderIsNull_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var query = new GetOrderDetailQuery(_context, _mapper);
            query.OrderId = Guid.NewGuid();

            //act&assert
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer cannot be found");
        }
    }
}
