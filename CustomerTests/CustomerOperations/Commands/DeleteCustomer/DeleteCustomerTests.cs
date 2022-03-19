using Customer.API.CustomerOperations.Commands.DeleteCustomer;
using CustomerAPI.Models.DbOperations;
using CustomerTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerTests.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerTests : IClassFixture<TestFixture>
    {
        private readonly CustomerDbContext _dbContext;

        public DeleteCustomerTests(TestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }

        [Fact]
        public void WhenCustomerIsNull_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            DeleteCustomerCommand command = new DeleteCustomerCommand(_dbContext);
            command.CustomerId = Guid.NewGuid();
            //act&assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer does not exist");
        }

        //[Fact]
        //public void WhenCustomerIdIsValid_Customer_ShouldBeDeleted()
        //{
        //    //arrange
        //    DeleteCustomerCommand command = new DeleteCustomerCommand(_dbContext);
        //    command.CustomerId = new Guid("7ebf8ba5-ba75-41f6-8104-a07600092990");

        //    //act
        //    FluentActions.Invoking(() => command.Handle()).Invoke();

        //    //assert
        //    var customer = _dbContext.Customers.SingleOrDefault(customer => customer.Email == "ferdi@mail.com");
        //    customer.Should().BeNull();


        //}

    }
}
