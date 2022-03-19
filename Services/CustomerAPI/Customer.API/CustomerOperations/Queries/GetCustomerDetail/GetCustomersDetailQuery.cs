using AutoMapper;
using CustomerAPI.Models.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomersDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly ICustomerDbContext _dbContext;

        public Guid CustomerId { get; set; }

        public GetCustomersDetailQuery(ICustomerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CustomerDetailViewModel Handle() 
        {
            var customer = _dbContext.Customers.Include(x => x.Address).SingleOrDefault(customer => customer.Id == CustomerId);
            if (customer is null)
                throw new InvalidOperationException("Customer cannot be found");

            CustomerDetailViewModel vm = _mapper.Map<CustomerDetailViewModel>(customer);
            return vm;
        }
    }

    public class CustomerDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
