using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.API.Clients;
using OrderAPI.Models;
using OrderAPI.Models.DbOperations;
using System.Linq;

namespace Order.API.OrderOperations.Queries.GetOrdersOfCustomer
{
    public class GetOrdersOfaCustomerQuery
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CustomerClient _customerClient;


        public Guid CustomerId { get; set; }

        public GetOrdersOfaCustomerQuery(IOrderDbContext dbContext, IMapper mapper, CustomerClient customerClient)
        {
            _customerClient = customerClient;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrdersOfCustomerViewModel>> Handle()
        {
            var customerList = await _customerClient.GetCustomersAsync();
            //var customer = customerList.SingleOrDefault(x => x.Id == CustomerId);

            //if (customer == null)
            //    throw new InvalidOperationException("There is no customer with the given customer Id");

            var orderList = _dbContext.Orders.Include(x => x.Address).Include(x => x.Product).Where(order => order.CustomerId == CustomerId).OrderBy(x => x.Id).ToList<OrderDTO>();

            List<OrdersOfCustomerViewModel> vm = _mapper.Map<List<OrdersOfCustomerViewModel>>(orderList);
            return vm;
        }
    }

    public class OrdersOfCustomerViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid AddressId { get; set; }
        public string Address { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
