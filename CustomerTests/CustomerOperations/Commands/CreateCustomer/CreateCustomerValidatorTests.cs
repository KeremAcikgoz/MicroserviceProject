using Customer.API.CustomerOperations.Commands.CreateCustomer;
using CustomerAPI.Models;
using CustomerTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerTests.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerValidatorTests : IClassFixture<TestFixture>
    {
        [Theory]
        [ClassData(typeof(CustomerClassData))]


        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(CreateCustomerModel customer)
        {
            //arrange
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = customer;

            //act
            CreateCustomerValidator validator = new CreateCustomerValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
