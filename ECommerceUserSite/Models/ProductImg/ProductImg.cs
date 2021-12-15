using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class ProductImg
    {
       public int ImgId { get; set; }
        public int ProductId { get; set; }
     
        public string  src { get; set; }

        public Product product { get; set; }

    }
}
