namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRateRepository
    {
        Task<int> AddRateAsync(Rates Rates);
        Task<List<Rates>> GetRatesAsync(int userId);
        Task<Rates> GetRateDetailsAsync(int value);
        Task<int> UpdateRateAsync(Rates Rates);
        Task<int> DeleteRateAsync(Rates Rates);
    }
}
