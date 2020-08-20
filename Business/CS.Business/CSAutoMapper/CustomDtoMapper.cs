using AutoMapper;
using CS.Business.Shared.Dto.Order;
using CS.Business.Shared.Dto.Product;
using CS.Core.Order;
using CS.Core.Product;

namespace CS.Business.AutoMapper
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        }
    }
}
