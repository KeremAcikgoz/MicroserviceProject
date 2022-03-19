using AutoMapper;
using CustomerAPI.Models;
using CustomerAPI.Models.DbOperations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.API.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }

        private readonly ICustomerDbContext _dbContext;

        private readonly IMapper _mapper;

        public CreateCustomerCommand(ICustomerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Guid Handle()
        {
            //var customer = _dbContext.Customers.SingleOrDefault(x => x.AddressId == Model.AddressId);
            //if (customer is not null)
            //    throw new InvalidOperationException("Customer already exists");

            var customer = _mapper.Map<CustomerDTO>(Model);

            if (_dbContext.Customers.SingleOrDefault(x => x.Email == customer.Email) != null)
                throw new InvalidOperationException("Email is already in use.");



            _dbContext.Addresses.Add(customer.Address);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer.Id;
        }

    }

    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        //public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
