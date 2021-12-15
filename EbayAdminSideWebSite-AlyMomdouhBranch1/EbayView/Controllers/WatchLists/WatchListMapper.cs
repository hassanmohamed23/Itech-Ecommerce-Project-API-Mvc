namespace EbayView.Controllers.WatchLists
{
    using AutoMapper;
    using EbayView.Models.ViewModel.WatchLists;
    using global::Models;

    public class WatchListMapper : Profile
    {
        public WatchListMapper()
        {
            CreateMap<WatchList, GetWatchListOutputModel>()
                .ForMember(dest => dest.FistName, opt => opt.MapFrom(src => src.user.FistName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.product.Name));
            CreateMap<WatchList, GetWatchListDetailsOutputModel>()
                .ForMember(dest => dest.FistName, opt => opt.MapFrom(src => src.user.FistName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.product.Name));


        }
    }
}
