namespace EbayAdminRepository.Shippers
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ShipperRepository : IShipperRepository
    {
        private readonly myDbContext _context;
        public ShipperRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddShipperAsync(Shipper Shipper)
        {
            await _context.Shippers.AddAsync(Shipper);

            await _context.SaveChangesAsync();


            return Shipper.ShipperId;
        }

        public async Task<int> DeleteShipperAsync(Shipper Shipper)
        {
            _context.Shippers.Remove(Shipper);
            await _context.SaveChangesAsync();
            return Shipper.ShipperId;
        }

        public async Task<Shipper> GetShipperDetailsAsync(int value)
        {
            return await _context.Shippers.Where(c => c.ShipperId == value).FirstOrDefaultAsync();
        }

        public async Task<List<Shipper>> GetShipperAsync()
        {
            return await _context.Shippers.ToListAsync();
        }

        public async Task<int> UpdateShipperAsync(Shipper Shipper)
        {
            _context.Update(Shipper);
            await _context.SaveChangesAsync();
            return Shipper.ShipperId;
        }

    }
}
