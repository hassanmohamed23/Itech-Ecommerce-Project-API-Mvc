namespace EbayView.Controllers.Users
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Category;
    using EbayView.Models.ViewModel.Users;
    using global::Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, GetUsersOutputModel>();
               CreateMap<User, GetUsersOutputModel>().ForMember(des => des.UserId, o => o.MapFrom(s => s.Id)).ReverseMap();
            CreateMap<User, GetUsserDetailsOutputModel>();
            CreateMap<User, GetUsserDetailsOutputModel>().ForMember(des => des.UserId, o => o.MapFrom(s => s.Id))
                                    .ForMember(des => des.Phone, o => o.MapFrom(s => s.PhoneNumber)).ReverseMap();

        }
    }
}
