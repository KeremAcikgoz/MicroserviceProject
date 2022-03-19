using AutoMapper;
using Order.API.OrderOperations.CreateOrder;
using Order.API.OrderOperations.Queries;
using Order.API.OrderOperations.Queries.GetOrdersOfCustomer;
using OrderAPI.Models;

namespace Order.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderViewModel, OrderDTO>();
            CreateMap<OrderDTO, OrdersViewModel>().ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address.AddressLine));
            CreateMap<OrderDTO, GetOrderDetailViewModel>().ForMember(dest => dest.Address,
                        opt => opt.MapFrom(src => src.Address.AddressLine));
            CreateMap<OrderDTO, OrdersOfCustomerViewModel>().ForMember(dest => dest.Address,
                        opt => opt.MapFrom(src => src.Address.AddressLine));
        }
    }
}
