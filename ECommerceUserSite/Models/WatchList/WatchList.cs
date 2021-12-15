using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class WatchList
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public User user { get; set; } 
        public Product product { get; set; }
    }
}
