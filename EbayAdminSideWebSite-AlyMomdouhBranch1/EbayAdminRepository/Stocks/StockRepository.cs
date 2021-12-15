namespace EbayAdminRepository.Stocks
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class StockRepository : IStockRepository
    {
        private readonly myDbContext _context;
        public StockRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddStockAsync(Stock stock)
        {
            await _context.stocks.AddAsync(stock);

            await _context.SaveChangesAsync();


            return stock.StockId;
        }

        public async Task<int> DeleteStockAsync(Stock stock)
        {
            _context.stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock.StockId;
        }

        public async Task<Stock> GetStockDetailsAsync(int value)
        {
            return await _context.stocks.Where(c => c.StockId == value).FirstOrDefaultAsync();
        }

        public async Task<List<Stock>> GetStockAsync()
        {
            return await _context.stocks.ToListAsync();
        }

        public async Task<int> UpdateStockAsync(Stock stock)
        {
            _context.Update(stock);
            await _context.SaveChangesAsync();
            return stock.StockId;
        }

    }
}
