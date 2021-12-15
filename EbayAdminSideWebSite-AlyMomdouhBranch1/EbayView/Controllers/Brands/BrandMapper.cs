namespace EbayView.Controllers.Brands
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Brands;
    using global::Models;

    public class BrandMapper : Profile
    {
        public BrandMapper()
        {
            CreateMap<CreateBrandInputModel, Brands>();
            CreateMap<Brands, GetBrandsOutputModel>();
            CreateMap<Brands, GetBrandDetailsOutputModel>();

        }
    }
}
