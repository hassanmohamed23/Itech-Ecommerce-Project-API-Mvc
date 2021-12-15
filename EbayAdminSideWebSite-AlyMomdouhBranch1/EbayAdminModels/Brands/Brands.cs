using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Brands
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
