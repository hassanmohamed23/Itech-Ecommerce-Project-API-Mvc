namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBrandRepository
    {
        Task<int> AddBrandAsync(Brands brands);
        Task<List<Brands>> GetBrandsAsync();
        Task<Brands> GetBrandDetailsAsync(int value);
        Task<int> UpdateBrandAsync(Brands brands);
        Task<int> DeleteBrandAsync(Brands brands);
    }
}
