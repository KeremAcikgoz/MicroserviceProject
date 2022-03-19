using FluentAssertions;
using Order.API.OrderOperations.Commands.CreateOrder;
using Order.API.OrderOperations.CreateOrder;
using OrderTests.OrderTestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTests.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderValidatorTests : IClassFixture<OrderTestFixture>
    {

        [Theory]
        [ClassData(typeof(OrderClassData))]

        public void WhenInvalidDataIsGiven_Validator_ShouldBeReturnErrors(CreateOrderViewModel order)
        {
            //arrange
            CreateOrderCommand command = new CreateOrderCommand(null, null);
            command.Model = order;

            //act
            CreateOrderValidator validator = new CreateOrderValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
