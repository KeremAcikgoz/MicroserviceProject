using AutoMapper;
using Customer.API.CustomerOperations.Commands.CreateCustomer;
using Customer.API.CustomerOperations.Commands.DeleteCustomer;
using Customer.API.CustomerOperations.Commands.UpdateCustomer;
using Customer.API.CustomerOperations.Queries.GetCustomerDetail;
using Customer.API.CustomerOperations.Queries.GetCustomers;
using CustomerAPI.Infrastructure;
using CustomerAPI.Models;
using CustomerAPI.Models.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly ICustomerService _customerService;
        //public CustomerController(ICustomerService customerService)
        //{ 
        //    _customerService = customerService;
        //}

        private readonly ICustomerDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);  
        }

        //[HttpGet("{Id}")]
        //public CustomerDTO GetCustomer(int Id)
        //{
        //    return _customerService.GetCustomerById(Id);
        //}

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            CustomerDetailViewModel result;

            GetCustomersDetailQuery query = new GetCustomersDetailQuery(_context, _mapper);
            query.CustomerId = id;
            GetCustomerDetailQueryValidator validator = new GetCustomerDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerModel newCustomer)
        {
            //CreateAddress command2 = new CreateAddress(_context, _mapper);
            //command2.Model = newCustomer.Address;
            //command2.Handle();

            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = newCustomer;
            command.Model.Address.Id = Guid.NewGuid();
            CreateCustomerValidator validator = new CreateCustomerValidator();
            validator.ValidateAndThrow(command);
            Guid newCustomerId = command.Handle();
            return Ok(newCustomerId);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(Guid id, [FromBody] UpdateCustomerModel updatedCustomer)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            command.CustomerId = id;
            command.Model = updatedCustomer;
            UpdateCustomerValidator validator = new UpdateCustomerValidator();
            validator.ValidateAndThrow(command);
            bool isUpdated = command.Handle();
            return Ok(isUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;
            bool isUpdated = command.Handle();
            return Ok(isUpdated);
        }
    }
}
