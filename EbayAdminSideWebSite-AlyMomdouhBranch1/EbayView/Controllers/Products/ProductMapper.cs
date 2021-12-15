namespace EbayView.Controllers.Products
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Products;
    using global::Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, GetProductsOutputModel>().ReverseMap();
            //GetProductsOutputModel = (Product)AutoMapper.Mapper.Map(GetProductsOutputModel, Product, typeof(GetProductsOutputModel), typeof(Product));

            CreateMap<CreateProductInputModel, Product>()
                .ForMember(dest => dest.ProductId, o => o.MapFrom(s => s.ProductId))
                .ForMember(dest => dest.Name, o => o.MapFrom(s => s.Name))
                .ForMember(dest => dest.Price, o => o.MapFrom(s => s.Price))
                .ForMember(dest => dest.Quantity, o => o.MapFrom(s => s.Quantity))
                .ForMember(dest => dest.Description, o => o.MapFrom(s => s.Description))
                .ForMember(dest => dest.AdminId, o => o.MapFrom(s => s.AdminId))
                .ForMember(dest => dest.SubCatId, o => o.MapFrom(s => s.SubCatId))
                .ForMember(dest => dest.StockId, o => o.MapFrom(s => s.StockId))
                .ForMember(dest => dest.BrandId, o => o.MapFrom(s => s.BrandId))
                .ForMember(dest => dest.CatId, o => o.MapFrom(s => s.CatId))
                .ForMember(dest => dest.productImgs, o => o.MapFrom(s => ProductImg.Create(s.imgspathes)))
                .ForAllOtherMembers(dest => dest.Ignore());

            // add by aly
            CreateMap<Product, GetProductDetailsOutputModel>()
                .ForMember(dest => dest.AdminName, o => o.MapFrom(s =>  s.Admin.FistName+" " +s.Admin.LastName ))
                .ForMember(dest => dest.categoryName, o => o.MapFrom(s => s.category.CategoryName))
                .ForMember(dest => dest.subcategoryName, o => o.MapFrom(s => s.subCategory.SubCatName))
                .ForMember(dest => dest.stockName, o => o.MapFrom(s => s.stock.StockName))
                .ForMember(dest => dest.brandName, o => o.MapFrom(s => s.brands.BrandName))
                .ForMember(dest => dest.rateNumber, o => o.MapFrom(s => s.rates.Count))
                .ForMember(dest => dest.commentNumber, o => o.MapFrom(s => s.comments.Count))
                .ForMember(dest => dest.productImgs, o => o.MapFrom(s => s.productImgs.
                                           Where(i=>i.ProductId==s.ProductId).Select(n=>n.src).ToArray()));
    }
    }
}
