using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public int UserId { get; set; } 
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float price { get; set; }

        public User user { get; set; }
        public Product product { get; set; }

        
         
    }
}
