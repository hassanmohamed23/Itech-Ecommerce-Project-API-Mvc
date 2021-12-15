namespace EbayAdminRepository.Homes
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Threading.Tasks;
    public class HomeRepository : IHomeRepository
    {
        private readonly myDbContext _context;
        public HomeRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<DataCount> GetDataCountAsync()
        {
            DataCount dataCount = new DataCount
            {
                ProductCount = await _context.Products.CountAsync(),
                BrandCount = await _context.Brands.CountAsync(),
                CategoryCount = await _context.Categories.CountAsync(),
                StockCount = await _context.stocks.CountAsync(),
               // UserCount = await _context.Users.CountAsync(),
                WatchListCount = await _context.WatchLists.CountAsync(),
                ShipperCount = await _context.Shippers.CountAsync(),
                OfferCount = await _context.Offers.CountAsync(),
                CartCount = await _context.Carts.CountAsync(),
                SubCategoryCount = await _context.SubCategories.CountAsync(),
                AdminCount = await _context.Admins.CountAsync(),
                OrderCount=await _context.Orders.CountAsync(),
                CommentCount = await _context.Comments.CountAsync()
            };

            return dataCount;
        }
    }
}
