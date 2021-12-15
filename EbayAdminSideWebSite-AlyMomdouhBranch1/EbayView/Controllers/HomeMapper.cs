namespace EbayView.Controllers
{
    using AutoMapper;
    using EbayView.Models.ViewModel;
    using global::Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeMapper : Profile
    {
        public HomeMapper()
        {
        CreateMap<DataCount, GetStatisticsOutputModel>();

        }

    }
}
