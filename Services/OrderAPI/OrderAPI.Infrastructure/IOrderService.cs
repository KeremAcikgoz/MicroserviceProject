using OrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure
{
    public interface IOrderService
    {
        public OrderDTO GetOrderById(int Id);
    }
}
