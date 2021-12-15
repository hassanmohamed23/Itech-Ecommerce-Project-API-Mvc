namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStockRepository
    {
        Task<int> AddStockAsync(Stock stock);
        Task<List<Stock>> GetStockAsync();
        Task<Stock> GetStockDetailsAsync(int value);
        Task<int> UpdateStockAsync(Stock stock);
        Task<int> DeleteStockAsync(Stock stock);
    }
}
