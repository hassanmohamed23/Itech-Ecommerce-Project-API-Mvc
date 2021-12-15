namespace EbayView.Controllers.Stocks
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Category;
    using EbayView.Models.ViewModel.Stocks;
    using global::Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class StockMapper : Profile
    {
        public StockMapper()
        {
            CreateMap<CreateStockInputModel, Stock>();
            CreateMap<Stock, GetStocksOutputModel>();
            CreateMap<Stock, GetStockDetailsOutputModel>();

        }
    }
}
