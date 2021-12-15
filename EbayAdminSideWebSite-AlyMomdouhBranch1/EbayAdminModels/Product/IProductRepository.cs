namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        Task<int> AddProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductDetailsAsync(int value);
        Task<int> UpdateProductAsync(Product product);
        Task<int> DeleteProductAsync(Product product);
        Task<int> GetProductCountAsync();
    }
}
