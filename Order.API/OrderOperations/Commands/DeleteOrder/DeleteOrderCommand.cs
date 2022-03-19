using OrderAPI.Models.DbOperations;

namespace Order.API.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        private readonly IOrderDbContext _context;

        public DeleteOrderCommand(IOrderDbContext context)
        {
            _context = context;
        }

        public Guid OrderId { get; set; }

        public bool Handle()
        {
            var customer = _context.Orders.SingleOrDefault(customer => customer.Id == OrderId);

            if (customer == null)
                throw new InvalidOperationException("Customer does not exist");

            _context.Orders.Remove(customer);
            _context.SaveChanges();
            return true;
        }
    }
}
