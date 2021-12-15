using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class SubCategory 
    {
        public int SubCategoryId { get; set; }
        public int CatId { get; set; }
        public string SubCatName { get; set; }

        public Category category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
