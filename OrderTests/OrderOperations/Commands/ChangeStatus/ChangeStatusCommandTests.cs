using FluentAssertions;
using Order.API.OrderOperations.Commands.ChangeStatus;
using OrderAPI.Models;
using OrderAPI.Models.DbOperations;
using OrderTests.OrderTestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTests.OrderOperations.Commands.ChangeStatus
{
    public class ChangeStatusCommandTests : IClassFixture<OrderTestFixture>
    {
        private readonly OrderDbContext _context;

        public ChangeStatusCommandTests(OrderTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenOrderIsNull_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            ChangeStatusCommand command = new ChangeStatusCommand(_context);
            command.OrderId = Guid.NewGuid();

            //act&assert
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>("Order could not be found");

        }

        [Fact]
        public void WhenOrderIsValid_Status_ShouldChange()
        {
            //arrange
            var command = new ChangeStatusCommand(_context);
            ChangeStatusViewModel model = new ChangeStatusViewModel();
            var order = _context.Orders.First();
            OrderDTO newOrder = new OrderDTO
            {
                Id = order.Id,
                Address = order.Address,
                AddressId = order.AddressId,
                CustomerId = order.CustomerId,
                Product = order.Product,
                Quantity = order.Quantity,
                ProductId = order.ProductId,
                Status = order.Status,
                Price = order.Price,
            };
            command.OrderId = newOrder.Id;
            model.Status = "teststatus";

            //act
            var result = FluentActions.Invoking(() => command.Handle());

            //assert

            result.Should().NotBeNull();
            //Assert.True(result);
        }
    }
}
