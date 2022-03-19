using AutoMapper;
using CustomerAPI.Models;
using FluentAssertions;
using Order.API.OrderOperations.CreateOrder;
using OrderAPI.Models;
using OrderAPI.Models.DbOperations;
using OrderTests.OrderTestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTests.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderTests : IClassFixture<OrderTestFixture>
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderTests(OrderTestFixture orderTestFixture)
        {
            _context = orderTestFixture.Context;
            _mapper = orderTestFixture.Mapper;
        }

        [Fact]
        public void WhenCustomerIsValid_InvalidOperationExceptionShouldBeReturn()
        {
            var order = new CreateOrderViewModel
            {
                Price = 20.1,
                Quantity = 1,
                Status = "Preparing",
                CustomerId = new Guid("2ebf8ba5-ba75-41f6-8104-a07600092190"),
                ProductId = new Guid("d03deeb8-8197-4699-a534-9d1316640303"),
                Address = new Address
                {
                    Id = new Guid("e91b827a-fb39-4440-98a7-c16388838881"),
                    City = "testcity",
                    CityCode = 31,
                    Country = "testcountry"
                }
            };
            //_context.Orders.Add(order);
            //_context.SaveChanges();

            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = order;


            //act&assert
            FluentActions.Invoking(() => command.Handle()).Invoke();


            //assert
            var newOrder = _context.Orders.FirstOrDefault(order => order.Id == order.Id);
            newOrder.Should().NotBeNull();
            //newOrder.Address.Should().NotBeNull();
            newOrder.Status.Should().NotBeNull();
            newOrder.CustomerId.Should().NotBeEmpty();
        }
    }
}
