namespace EbayView.Controllers.Orders
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Orders;
    using global::Models;

    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, GetOrdersOutputModel>()
                .ForMember(dest => dest.FistName, opt => opt.MapFrom(src => src.user.FistName));

            CreateMap<Order, GetOrderDetailsOutputModel>()
                .ForMember(dest => dest.FistName, opt => opt.MapFrom(src => src.user.FistName))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.orderItems));
            CreateMap<OrderItem, GetOrderItem>()
;

        }
    }
}
