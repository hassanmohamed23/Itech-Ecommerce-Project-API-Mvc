using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Models.ViewModel.Comments
{
    public class GetCommentOutputModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        // add by aly
        public string UserName { get; set; }
        public string ProductName { get; set; }

    }
}
