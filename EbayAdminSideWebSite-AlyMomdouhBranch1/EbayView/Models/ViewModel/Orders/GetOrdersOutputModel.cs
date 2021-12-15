using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Models.ViewModel.Orders
{
    public class GetOrdersOutputModel
    {
        public int OrderId { get; set; }
        public float TotalPrice { get; set; }
        public int UserId { get; set; }
        public string FistName { get; set; }

    }
}
