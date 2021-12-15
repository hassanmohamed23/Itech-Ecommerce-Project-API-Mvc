namespace EbayAdminRepository.SubCategory
{
    using EbayAdminDbContext;
    using EbayAdminModels.SubCategory;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly myDbContext _context;
        public SubCategoryRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddSubCategoryAsync(SubCategory Subcategory)
        {
            await _context.AddAsync(Subcategory);
            await _context.SaveChangesAsync();
            return Subcategory.SubCategoryId;
        }

        public Task<int> DeleteCategoryAsync(SubCategory subCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteSubCategoryAsync(SubCategory Subcategory)
        {
            _context.Remove(Subcategory);
            await _context.SaveChangesAsync();
            return Subcategory.SubCategoryId;
        }

        public async Task<List<SubCategory>> GetSubCategoriesAsync()
        {
            return await _context.SubCategories.ToListAsync();
        }

        public async Task<SubCategory> GetSubCategoryDetailsAsync(int value)
        {
            return await _context.SubCategories.Where(c => c.SubCategoryId == value).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateSubCategoryAsync(SubCategory Subcategory)
        {
            _context.Update(Subcategory);
            await _context.SaveChangesAsync();
            return Subcategory.SubCategoryId;
        }
    }
}
