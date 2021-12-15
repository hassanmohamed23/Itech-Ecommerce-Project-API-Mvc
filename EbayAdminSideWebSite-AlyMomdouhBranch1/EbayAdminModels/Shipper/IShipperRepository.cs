namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IShipperRepository
    {
        Task<int> AddShipperAsync(Shipper Shipper);
        Task<List<Shipper>> GetShipperAsync();
        Task<Shipper> GetShipperDetailsAsync(int value);
        Task<int> UpdateShipperAsync(Shipper Shipper);
        Task<int> DeleteShipperAsync(Shipper Shipper);
    }
}
