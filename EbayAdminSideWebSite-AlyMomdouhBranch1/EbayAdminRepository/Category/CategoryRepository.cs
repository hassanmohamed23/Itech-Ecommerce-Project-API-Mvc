namespace EbayAdminRepository.Category
{
    using EbayAdminDbContext;
    using EbayAdminModels.Category;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly myDbContext _context;
        public CategoryRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddCategoryAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<int> DeleteCategoryAsync(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryDetailsAsync(int value)
        {
            return await _context.Categories.Where(c => c.CategoryId == value).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category.CategoryId;
        }
    }
}
