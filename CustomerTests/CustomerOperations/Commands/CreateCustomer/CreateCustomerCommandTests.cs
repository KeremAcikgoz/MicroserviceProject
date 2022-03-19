using AutoMapper;
using CustomerAPI.Models;
using CustomerAPI.Models.DbOperations;
using CustomerTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.API.CustomerOperations.Commands;
using Xunit;
using Customer.API.CustomerOperations.Commands.CreateCustomer;
using FluentAssertions;

namespace CustomerTests.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandTests : IClassFixture<TestFixture>
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandTests(TestFixture  testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyUsedEmailIsGıven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var customer = new CustomerDTO
            {
                Email = "WhenAlreadyUsedEmailIsGıven_InvalidOperationException_ShouldBeReturn",
                Name = "Test",
                Address = new Address
                {
                    Id = new Guid("0030aebf-cefd-4cce-820a-d8741658f7d9"),
                    City = "Genel",
                    Country = "tr",
                    CityCode = 31
                }
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = new CreateCustomerModel()
            {
                Name = customer.Name,
                Address = customer.Address,                
                Email = customer.Email
            };

            //act&assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Email is already in use.");

            //assertion
        }
            [Fact]
            public void WhenValidInputsAreGiven_Customer_ShouldBeCreated()
            {
                //arrange
                CreateCustomerCommand command =
                    new CreateCustomerCommand(_context, _mapper);
                CreateCustomerModel model =
                    new CreateCustomerModel()
                    {
                        Name = "Szalai",
                        Email = "kerme@mail.com",
                        Address = new Address
                        {
                            Id = new Guid("0dccfca1-4fc1-447b-8355-16928c132d08"),
                            Country = "ee",
                            City = "Budapewwst",
                            CityCode = 1212,
                        }
                    };
                command.Model = model;
                //act
                FluentActions.Invoking(() => command.Handle()).Invoke();

                //assert
                var customer = _context.Customers.SingleOrDefault(customer => customer.Email == model.Email);
                customer.Should().NotBeNull();
                customer.Email.Should().Be(model.Email);
                customer.Name.Should().Be(model.Name);
                customer.Address.Should().Be(model.Address);
            }
    }
}
