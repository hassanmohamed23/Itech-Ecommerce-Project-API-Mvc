using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Models.ViewModel.Offers
{
    public class GetOfferOutputModel
    {
        public int OfferId { get; set; }
        public int ProductId { get; set; }
        public float NewPrice { get; set; } 
        public int Precentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // add by aly 
        public float OldPrice { get; set; }
        public string ProductName { get; set; }
    }
}
