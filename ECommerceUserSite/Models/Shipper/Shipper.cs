using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string  URL { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
