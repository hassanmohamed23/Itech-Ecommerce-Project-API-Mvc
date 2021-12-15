namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWatchListRepository
    {
        Task<int> AddWatchListAsync(WatchList WatchList);
        Task<List<WatchList>> GetWatchListAsync();
        Task<WatchList> GetWatchListDetailsAsync(int value);
        Task<int> UpdateWatchListAsync(WatchList WatchList);
        Task<int> DeleteWatchListAsync(WatchList WatchList);
    }
}
