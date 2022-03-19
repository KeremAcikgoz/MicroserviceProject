using AutoMapper;
using FluentAssertions;
using Order.API.OrderOperations.Commands.DeleteOrder;
using OrderAPI.Models.DbOperations;
using OrderTests.OrderTestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTests.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderTests : IClassFixture<OrderTestFixture>
    {
        private readonly OrderDbContext _context;

        public DeleteOrderTests(OrderTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenOrderIsNull_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = Guid.NewGuid();

            //act&assert

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer does not exist");
        }

    }
}
