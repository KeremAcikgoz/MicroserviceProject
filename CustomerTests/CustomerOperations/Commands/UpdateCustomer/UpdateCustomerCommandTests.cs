using AutoMapper;
using CustomerAPI.Models;
using CustomerAPI.Models.DbOperations;
using CustomerTests.TestSetup;
using System;
using Customer.API.CustomerOperations.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Customer.API.CustomerOperations.Commands.UpdateCustomer;

namespace CustomerTests.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandTests :IClassFixture<TestFixture>
    {
        private readonly CustomerDbContext _context;

        public UpdateCustomerCommandTests(TestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenCustomerIsNull_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            command.CustomerId = Guid.NewGuid();
            command.Model = new UpdateCustomerModel()
            {
                Email = "updatetest@mail.com",
                Name = "updatetestname",
                Address = new Address { City = "ff", CityCode = 3112, Country =  "ss" }
            };

            //act&assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer could not be found");
        }
    }
}
