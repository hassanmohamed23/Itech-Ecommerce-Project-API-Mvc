namespace EbayAdminRepository.Rates
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RateRepository : IRateRepository
    {
        private readonly myDbContext _context;
        public RateRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddRateAsync(Rates Rate)
        {
            await _context.Rates.AddAsync(Rate);

            await _context.SaveChangesAsync();


            return Rate.UserId;
        }

        public async Task<int> DeleteRateAsync(Rates Rate)
        {
            _context.Rates.Remove(Rate);
            await _context.SaveChangesAsync();
            return Rate.UserId;
        }

        public async Task<Rates> GetRateDetailsAsync(int value)
        {
            return await _context.Rates.Where(c => c.UserId == value).FirstOrDefaultAsync();
        }

        public async Task<List<Rates>> GetRatesAsync(int value)
        {
            return await _context.Rates.Where(c => c.UserId == value).ToListAsync();
        }

        public async Task<int> UpdateRateAsync(Rates Rates)
        {
            _context.Update(Rates);
            await _context.SaveChangesAsync();
            return Rates.UserId;
        }

        
    }

}
   
