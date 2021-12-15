namespace EbayView.Models.ViewModel.Products
{
    public class GetProductDetailsOutputModel  //Details
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        int AdminId { get; set; }
        public string AdminName { get; set; }

        // add more
        public string categoryName { get; set; }
        public string subcategoryName { get; set; }
        public string stockName { get; set; }
        public string brandName { get; set; }
        public string[] productImgs { get; set; }
        public int rateNumber { get; set; }
        public int commentNumber { get; set; }

    }
}
