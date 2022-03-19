using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;
using OrderAPI.Models.DbOperations;

namespace Order.API.OrderOperations.Queries
{
    public class GetOrderDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly IOrderDbContext _dbContext;

        public Guid OrderId { get; set; }

        public GetOrderDetailQuery(IOrderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetOrderDetailViewModel Handle()
        {
            var order = _dbContext.Orders.Include(x => x.Address).Include(x => x.Product).SingleOrDefault(order => order.Id == OrderId);
            if (order is null)
                throw new InvalidOperationException("Customer cannot be found");

            GetOrderDetailViewModel vm = _mapper.Map<GetOrderDetailViewModel>(order);
            return vm;
        }
    }

    public class GetOrderDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Address { get; set; }
        public Product Product { get; set; }
    }
}
