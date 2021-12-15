namespace EbayView.Models.ViewModel.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class GetCategoriesOutputModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        // add by aly
        public int ProductInCategory { get; set; }
    }
}
