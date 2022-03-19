using AutoMapper;
using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;
using OrderAPI.Models.DbOperations;

namespace Order.API.OrderOperations.Queries
{
    public class GetOrderQuery
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderQuery(IOrderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<OrdersViewModel> Handle()
        {
            var orderList = _dbContext.Orders.Include(x => x.Address).Include(x => x.Product).OrderBy(x => x.Id).ToList<OrderDTO>();
            List<OrdersViewModel> vm = _mapper.Map<List<OrdersViewModel>>(orderList);
            return vm;
        }
    }

    public class OrdersViewModel
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
