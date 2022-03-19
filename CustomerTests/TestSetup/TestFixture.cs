using AutoMapper;
using Customer.API.Common;
using CustomerAPI.Models.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTests.TestSetup
{
    public class TestFixture
    {
        public CustomerDbContext Context {get;set;}
        public IMapper Mapper { get; set; }

        public TestFixture()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>().UseInMemoryDatabase("CustomerTestDb").Options;
            Context = new CustomerDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddCustomers();
            Context.AddAddresses();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg =>
            { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }

    }
}
