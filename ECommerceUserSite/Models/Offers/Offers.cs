using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class Offers 
    {
       public int OfferId { get; set; }
        public int ProductId { get; set; }
        public int AdminId { get; set; }
        public float NewPrice { get; set; }
        public float OldPrice { get; set; }
        public int Precentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Product product { get; set; }
        public Admin admin { get; set; }
    }
}
