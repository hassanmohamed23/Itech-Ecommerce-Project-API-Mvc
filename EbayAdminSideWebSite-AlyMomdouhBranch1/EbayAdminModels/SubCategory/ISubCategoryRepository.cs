namespace EbayAdminModels.SubCategory
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubCategoryRepository
    {
        Task<int> AddSubCategoryAsync(SubCategory Subcategory);
        Task<List<SubCategory>> GetSubCategoriesAsync();
        Task<SubCategory> GetSubCategoryDetailsAsync(int value);
        Task<int> UpdateSubCategoryAsync(SubCategory subCategory);
        Task<int> DeleteSubCategoryAsync(SubCategory subCategory);
    }
}
