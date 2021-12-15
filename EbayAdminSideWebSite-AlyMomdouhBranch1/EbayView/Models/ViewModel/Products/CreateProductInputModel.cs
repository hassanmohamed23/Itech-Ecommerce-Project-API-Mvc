namespace EbayView.Models.ViewModel.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using EbayView.Models.ViewModel.Brands;
    using EbayView.Models.ViewModel.Category;
    using EbayView.Models.ViewModel.Stocks;
    using EbayView.Models.ViewModel.SubCategory;
    using global::Models;// add by aly

    public class CreateProductInputModel   // for edite and create
    {    
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Price is Required")]
        public float Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "AdminId Is Required")]
        public int AdminId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "CatId Is Required")]
        public int CatId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "BrandId Is Required")]
        public int BrandId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "StockId Is Required")]
        public int StockId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "SubCatId Is Required")]

        public int SubCatId { get; set; }
        public string[] imgspathes { get; set; }
         
        //   added by aly   get names from db to select 
        //public List<GetCategoriesOutputModel> AvailableCategories { get; set; }
        //public List<GetSubCategoriesOutputModel> AvailableSubCategories { get; set; }
        //public List<GetBrandsOutputModel> AvailableBrands { get; set; }
        //public List<GetStocksOutputModel> AvailableStock { get; set; }
         
    }
}
