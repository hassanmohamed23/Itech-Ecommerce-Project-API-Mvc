using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public partial class Rates
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Rate { get; set; } 
    }
    public partial class Rates
    {
        public User user { get; set; }
        public Product product { get; set; }
    }
}
