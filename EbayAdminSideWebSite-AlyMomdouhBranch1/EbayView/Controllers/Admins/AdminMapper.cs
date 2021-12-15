namespace EbayView.Controllers.Admins
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Category;
    using EbayView.Models.ViewModel.admns;
    using global::Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EbayView.Models.ViewModel.Account;

    public class AdminMapper : Profile
    {
        public AdminMapper()
        {
            CreateMap<CreateAdminInputModel, Admin>();
            CreateMap<Admin, GetAdminsOutputModel>().ReverseMap();
            CreateMap<Admin, GetAdminDetailsOutputModel>().ReverseMap();
            CreateMap<Admin, PostLoginModel>().ReverseMap();

        }
    }
}
