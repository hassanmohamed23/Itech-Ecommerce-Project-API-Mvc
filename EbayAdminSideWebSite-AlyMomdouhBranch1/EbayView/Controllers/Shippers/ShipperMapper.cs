namespace EbayView.Controllers.Shippers
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Category;
    using EbayView.Models.ViewModel.Shippers;
    using global::Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ShipperMapper : Profile
    {
        public ShipperMapper()
        {
            CreateMap<CreateShipperInputModel, Shipper>().ReverseMap();
            CreateMap<Shipper, GetShippersOutputModel>();
            CreateMap<Shipper, GetShipperDetailsOutputModel>();

        }
    }
}
