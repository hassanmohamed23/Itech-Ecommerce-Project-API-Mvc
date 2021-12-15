namespace EbayAdminRepository.WatchLists
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class WatchListRepository : IWatchListRepository
    {
        private readonly myDbContext _context;
        public WatchListRepository(myDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddWatchListAsync(WatchList WatchList)
        {
            await _context.WatchLists.AddAsync(WatchList);

            await _context.SaveChangesAsync();

            return WatchList.UserId;
        }

        public async Task<int> DeleteWatchListAsync(WatchList WatchList)
        {
            _context.WatchLists.Remove(WatchList);
            await _context.SaveChangesAsync();
            return WatchList.UserId;
        }

        public async Task<List<WatchList>> GetWatchListAsync()
        {
            return await _context.WatchLists.ToListAsync();
        }

        public async Task<WatchList> GetWatchListDetailsAsync(int value)
        {
            return await _context.WatchLists.Where(c => c.UserId == value).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateWatchListAsync(WatchList WatchList)
        {
            _context.Update(WatchList);
            await _context.SaveChangesAsync();
            return WatchList.UserId;
        }

        
    }
}
