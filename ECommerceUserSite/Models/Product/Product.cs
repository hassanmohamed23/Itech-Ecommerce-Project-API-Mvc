using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public partial class Product 
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float  Price { get; set; }
        public int Quantity { get; set; }
        public string Description  { get; set; }
        public  int AdminId  { get; set; }
        public int CatId  { get; set; }
        public int BrandId { get; set; }
        public int StockId { get; set; }
        public int SubCatId { get; set; } 
    }
    public partial class Product
    {
        public Admin Admin { get; set; }
        public Category category { get; set; }
        public Brands brands { get; set; }
        public Stock stock { get; set; }
        public SubCategory subCategory { get; set; }
        public ICollection<Rates> rates { get; set; }
        public ICollection<Cart> carts { get; set; }
        public ICollection<Comment> comments { get; set; }
        public ICollection<Offers> offers { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
        public ICollection<ProductImg> productImgs { get; set; }
        public ICollection<WatchList> watchLists { get; set; }

    }
}
