using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Models.DbOperations;

namespace Order.API.OrderOperations.Commands.ChangeStatus
{
    public class ChangeStatusCommand
    {
        private readonly IOrderDbContext _dbContext;

        public Guid OrderId { get; set; }

        public ChangeStatusViewModel Model { get; set; }

        public ChangeStatusCommand(IOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Handle()
        {   
            var order = _dbContext.Orders.SingleOrDefault(book => book.Id == OrderId);
            if (order is null)
                throw new InvalidOperationException("Order could not be found");

            order.Status = Model.Status != default ? Model.Status : order.Status;

            _dbContext.SaveChanges();
            return true;
        }

    }

    public class ChangeStatusViewModel
    {
        public string Status { get; set; }
    }
}
