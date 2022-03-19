using CustomerAPI.Models;
using OrderAPI.Models;
using OrderAPI.Models.DbOperations;

namespace Order.API.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrder
    {
        private readonly IOrderDbContext _context;

        public Guid OrderId { get; set; }

        public UpdatedOrderModel Model;

        public UpdateOrder(IOrderDbContext context)
        {
            _context = context;
        }

        public bool Handle()
        {
            var order = _context.Orders.SingleOrDefault(book => book.Id == OrderId);
            if (order is null)
                throw new InvalidOperationException("Order could not be found");

            var updatedAddress = new Address
            {
                City = Model.Address.City,
                Country = Model.Address.Country,
                CityCode = Model.Address.CityCode,
            };
            var updatedProduct = new Product
            {
                ImageUrl = Model.Product.ImageUrl,
                Name = Model.Product.Name,
            };

            order.Address = updatedAddress != default ? updatedAddress : order.Address;
            order.Product = Model.Product != default ? updatedProduct : order.Product;
            order.Quantity = Model.Quantity != default ? Model.Quantity : order.Quantity;
            order.Price = Model.Price != default ? Model.Price : order.Price;
            order.Status = Model.Status != default ? Model.Status : order.Status;


            _context.SaveChanges();
            return true;
        }
    }
    public class UpdatedOrderModel
    {
        public string Name { get; set; }       
        public string Status { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
        public Address Address { get; set; }
    }
}
