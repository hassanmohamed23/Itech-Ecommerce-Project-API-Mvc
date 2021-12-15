namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOfferRepository
    {
        Task<int> AddOfferAsync(Offers Offers);
        Task<List<Offers>> GetOffersAsync();
        Task<Offers> GetOfferDetailsAsync(int value);
        Task<int> UpdateOfferAsync(Offers Offers);
        Task<int> DeleteOfferAsync(Offers Offers);
    }
}
