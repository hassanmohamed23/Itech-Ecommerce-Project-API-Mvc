namespace EbayAdminRepository.Offers
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OfferRepository : IOfferRepository
    {
        private readonly myDbContext _context;
        public OfferRepository(myDbContext context)
        {
            _context = context;
        }
        //public async Task<int> AddBrandAsync(Offers Offer)
        //{
        //    await _context.Offers.AddAsync(Offer);
        //    await _context.SaveChangesAsync();
        //    return Offer.OfferId;
        //}

        public async Task<int> AddOfferAsync(Offers Offers)
        {
            //throw new System.NotImplementedException();
            await _context.Offers.AddAsync(Offers);
            await _context.SaveChangesAsync();
            return Offers.OfferId;
        }

        public async Task<int> DeleteOfferAsync(Offers Offer)
        {
            _context.Offers.Remove(Offer);
            await _context.SaveChangesAsync();
            return Offer.OfferId;
        }

        public async Task<Offers> GetOfferDetailsAsync(int value)
        {
            return await _context.Offers.Where(c => c.OfferId == value).FirstOrDefaultAsync();
        }

        public async Task<List<Offers>> GetOffersAsync()
        {
            return await _context.Offers.ToListAsync();
        }


        public async Task<int> UpdateOfferAsync(Offers Offers)
        {
            _context.Update(Offers);
            await _context.SaveChangesAsync();
            return Offers.OfferId;
        }


    }
}
