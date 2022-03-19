using CustomerAPI.Models;
using CustomerAPI.Models.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly ICustomerDbContext _context;

        public Guid CustomerId { get; set; }

        public UpdateCustomerModel Model;

        public UpdateCustomerCommand(ICustomerDbContext context)
        {
            _context = context;
        }

        public bool Handle()
        {
            var customer = _context.Customers.SingleOrDefault(book => book.Id == CustomerId);
            if (customer is null)
                throw new InvalidOperationException("Customer could not be found");

            //customer.Address = Model.Address != default ? Model.Address : customer.Address;
            //var address = new Address
            //{
            //    City = Model.Address.City,
            //    Country = Model.Address.Country,
            //    CityCode = Model.Address.CityCode,
            //    Id = Model.Address.Id
            //};
            //_context.SaveChanges();
            //customer.Address = address;
            var updatedAddress = new Address
            {
                City = Model.Address.City,
                Country = Model.Address.Country,
                CityCode = Model.Address.CityCode,
            };
            //customer.Address.City = updatedAddress.City != default ? updatedAddress.City : customer.Address.City;
            //customer.Address.Country = updatedAddress.Country != default ? updatedAddress.Country : customer.Address.Country;
            //customer.Address.CityCode = updatedAddress.CityCode != default ? updatedAddress.CityCode : customer.Address.CityCode;
            customer.Address = updatedAddress != default ? updatedAddress : customer.Address;
            customer.Name = Model.Name != default ? Model.Name : customer.Name;
            customer.Email = Model.Email != default ? Model.Email : customer.Email;


            _context.SaveChanges();
            return true;
        }
    }

    public class UpdateCustomerModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
