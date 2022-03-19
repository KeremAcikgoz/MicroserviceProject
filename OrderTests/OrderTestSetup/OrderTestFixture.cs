using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.API.Clients;
using Order.API.Common;
using OrderAPI.Models.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTests.OrderTestSetup
{
    public class OrderTestFixture 
    {
        public OrderDbContext Context { get; set; }

        public IMapper Mapper { get; set; }

        public CustomerClient CustomerClient { get; set; }

        public OrderTestFixture()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>().UseInMemoryDatabase("OrderTestDb").Options;
            Context = new OrderDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddOrders();
            Context.AddProducts();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg =>
            { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }


    }
}
