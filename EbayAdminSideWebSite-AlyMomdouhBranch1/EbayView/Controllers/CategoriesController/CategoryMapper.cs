namespace EbayView.Controllers.CategoriesController
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Category;
    using global::Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CreateCategoryInputModel, Category>().ReverseMap();
            CreateMap< Category,GetCategoriesOutputModel>().ReverseMap();
            CreateMap< Category, GetCategoryDetailsOutputModel>().ReverseMap();
            // add by aly
            CreateMap< Category, GetCategoriesOutputModel>() 
                .ForMember(des=>des.ProductInCategory,conf=>conf.MapFrom(
                    s=>s.Products.Count()));
                    //s=>s.Products.Where(p=>p.CatId==s.CategoryId).Select(p=>p.ProductId).Count()));

        }
    }
}
