using CustomerAPI.Models;
using AutoMapper;
using static Customer.API.CustomerOperations.Queries.GetCustomers.GetCustomersQuery;
using Customer.API.CustomerOperations.Queries.GetCustomerDetail;
using Customer.API.CustomerOperations.Commands.CreateCustomer;

namespace Customer.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDTO, CustomersViewModel>().ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address.AddressLine));
            CreateMap<CustomerDTO, CustomerDetailViewModel>().ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address.AddressLine));
            CreateMap<CreateCustomerModel, CustomerDTO>();
        }
    }
}
