using AutoMapper;
using CustomerAPI.Models.DbOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Clients;
using Order.API.OrderOperations.Commands.ChangeStatus;
using Order.API.OrderOperations.Commands.CreateOrder;
using Order.API.OrderOperations.Commands.DeleteOrder;
using Order.API.OrderOperations.Commands.UpdateOrder;
using Order.API.OrderOperations.CreateOrder;
using Order.API.OrderOperations.Queries;
using Order.API.OrderOperations.Queries.GetOrdersOfCustomer;
using OrderAPI.Models;
using OrderAPI.Models.DbOperations;

namespace Order.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;
        private readonly CustomerClient _customerClient;

        public OrderController(IOrderDbContext context, IMapper mapper, CustomerClient customerClient)
        {
            _context = context;
            _mapper = mapper;
            _customerClient = customerClient;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            GetOrderQuery query = new GetOrderQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            GetOrderDetailViewModel result;

            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.OrderId = id;
            //GetCustomerDetailQueryValidator validator = new GetCustomerDetailQueryValidator();
            //validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpGet("Customers/{id}")]
        public async Task<IActionResult> GetOrdersByCustomerId(Guid id)
        {
            GetOrdersOfaCustomerQuery query = new GetOrdersOfaCustomerQuery(_context, _mapper, _customerClient);
            query.CustomerId = id;
            var result = await query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderViewModel newOrder)
        {
            //CreateAddress command2 = new CreateAddress(_context, _mapper);
            //command2.Model = newCustomer.Address;
            //command2.Handle();

            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = newOrder;

            var customerList = await _customerClient.GetCustomersAsync();
            var customer = customerList.SingleOrDefault(x => x.Id == command.Model.CustomerId);
            if (customer == null)
                throw new InvalidOperationException("Customer could not be found");

            command.Model.Address.Id = Guid.NewGuid();
            //command.Model.CustomerId = id;

            var product = _context.Products.SingleOrDefault(p => p.Id == command.Model.ProductId);
            if (product == null)
                throw new InvalidOperationException("Product could not be found");

            command.Model.ProductId = product.Id;

            CreateOrderValidator validator = new CreateOrderValidator();
            validator.ValidateAndThrow(command);
            Guid newOrderId = command.Handle();
            return Ok(newOrderId);
        }



        [HttpPut("{id}")]
        public IActionResult UpdateOrder(Guid id, [FromBody] UpdatedOrderModel updatedOrder)
        {
            UpdateOrder command = new UpdateOrder(_context);
            command.OrderId = id;
            command.Model = updatedOrder;
            //UpdateCustomerValidator validator = new UpdateCustomerValidator();
            //validator.ValidateAndThrow(command);
            bool isUpdated = command.Handle();
            return Ok(isUpdated);
        }

        [HttpPatch("{id}")]
        public IActionResult ChangeStatus(Guid id, [FromBody] ChangeStatusViewModel model)
        {
            ChangeStatusCommand command = new ChangeStatusCommand(_context);
            command.OrderId = id;
            command.Model = model;
            bool isUpdated = command.Handle();
            return Ok(isUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = id;
            bool isUpdated = command.Handle();
            return Ok(isUpdated);
        }
    }
}
