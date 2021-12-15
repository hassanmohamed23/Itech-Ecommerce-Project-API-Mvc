namespace EbayView.Models.ViewModel.Products
{
    using EbayView.Models.ViewModel.Brands;
    using EbayView.Models.ViewModel.Category;
    using EbayView.Models.ViewModel.Stocks;
    using System.Collections.Generic;

    public class GetMetaDataOutputModel
    {
        public List<GetCategoriesOutputModel> Categories { get; set; }
        public List<GetBrandsOutputModel> Brands { get; set; }
        public List<GetStocksOutputModel> Stocks { get; set; }


    }
}
