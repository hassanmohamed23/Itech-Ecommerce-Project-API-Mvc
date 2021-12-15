namespace EbayView.Controllers.Rates
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Category;
    using EbayView.Models.ViewModel.Rates;
    using global::Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RateMapper : Profile
    {
        public RateMapper()
        {
            CreateMap<GetRateOutputModel, Rates>();

        }
    }
}
