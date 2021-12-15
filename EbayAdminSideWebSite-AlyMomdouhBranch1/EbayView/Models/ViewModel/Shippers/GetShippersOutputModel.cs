using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Models.ViewModel.Shippers
{
    public class GetShippersOutputModel
    {
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string URL { get; set; }
    }
}
