namespace EbayAdminRepository.Brands
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BrandRepository : IBrandRepository
    {
        private readonly myDbContext _context;
        public BrandRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddBrandAsync(Brands Brand)
        {
            await _context.Brands.AddAsync(Brand);
            await _context.SaveChangesAsync();
            return Brand.BrandId;
        }

        public async Task<int> DeleteBrandAsync(Brands Brand)
        {
            _context.Brands.Remove(Brand);
            await _context.SaveChangesAsync();
            return Brand.BrandId;
        }

        public async Task<Brands> GetBrandDetailsAsync(int value)
        {
            return await _context.Brands.Where(c => c.BrandId == value).FirstOrDefaultAsync();
        }

        public async Task<List<Brands>> GetBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }


        public async Task<int> UpdateBrandAsync(Brands brands)
        {
            _context.Update(brands);
            await _context.SaveChangesAsync();
            return brands.BrandId;
        }


    }
}
