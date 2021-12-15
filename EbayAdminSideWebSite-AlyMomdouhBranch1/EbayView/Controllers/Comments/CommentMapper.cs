namespace EbayView.Controllers.Comments
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Category;
    using EbayView.Models.ViewModel.Comments;
    using global::Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentMapper : Profile
    {
        public CommentMapper()
        {
            CreateMap<GetCommentOutputModel, Comment>();
            CreateMap<Comment, GetCommentOutputModel > ();

            ///  add by aly 
            CreateMap<Comment, GetCommentOutputModel>()
                .ForMember(des => des.ProductName, o => o.MapFrom(s=>s.product.Name))
                .ForMember(des => des.UserName, o => o.MapFrom(s=>s.user.FistName+" "+s.user.LastName));
             
        }
    }
}
