using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class Stock
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
        public string StockAddress { get; set; }


        public ICollection<Product> Products { get; set; }

    }
}
