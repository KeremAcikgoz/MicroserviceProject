using AutoMapper;
using CustomerAPI.Models;
using CustomerAPI.Models.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.CustomerOperations.Queries.GetCustomers
{
    public class GetCustomersQuery
    {
        private readonly ICustomerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomersQuery(ICustomerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<CustomersViewModel> Handle()
        {
            var customerList = _dbContext.Customers.Include(x => x.Address).OrderBy(x => x.Id).ToList<CustomerDTO>();
            List<CustomersViewModel> vm = _mapper.Map<List<CustomersViewModel>>(customerList);
            return vm;
        }
        public class CustomersViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

            public Guid AddressId { get; set; }
            public string Address { get; set; }

        }
    }
}
