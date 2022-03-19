using AutoMapper;
using CustomerAPI.Models;
using CustomerAPI.Models.DbOperations;
using Microsoft.EntityFrameworkCore;
using Order.API.OrderOperations.Commands.CreateOrder;
using OrderAPI.Models;
using OrderAPI.Models.DbOperations;

namespace Order.API.OrderOperations.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderViewModel Model { get; set; }

        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        //public Guid CustomerId { get; set; }

        public CreateOrderCommand(IOrderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Guid Handle()
        {
            
            var order = _mapper.Map<OrderDTO>(Model);

            _dbContext.Addresses.Add(order.Address);
            //_dbContext.Products.Add(order.Product);
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order.Id;
        }

    }
    public class CreateOrderViewModel
    {
        public Guid CustomerId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Guid ProductId { get; set; }
    }
}
