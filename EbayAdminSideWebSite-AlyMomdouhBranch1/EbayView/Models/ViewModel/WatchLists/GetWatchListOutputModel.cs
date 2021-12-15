using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Models.ViewModel.WatchLists
{
    public class GetWatchListOutputModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string FistName { get; set; }
        public string ProductName { get; set; }
    }
}
