using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Models.ViewModel.Rates
{
    public class GetRateOutputModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Rate { get; set; }
    }
}
