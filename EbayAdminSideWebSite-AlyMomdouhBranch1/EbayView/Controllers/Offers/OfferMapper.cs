namespace EbayView.Controllers.Offers
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Offers;
    using global::Models;

    public class BrandMapper : Profile
    {
        public BrandMapper()
        {
            CreateMap<CreateOffersInputModel, Offers>();
            CreateMap<Offers, GetOfferOutputModel>().ReverseMap();
            CreateMap<Offers, GetOfferDetailsOutputModel>();

            CreateMap<Offers, GetOfferDetailsOutputModel>()
                .ForMember(des=>des.OldPrice,o=>o.MapFrom(s=>s.product.Price));
        }
    }
}
