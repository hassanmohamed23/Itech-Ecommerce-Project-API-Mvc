using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class PaymentWay 
    {
        public int PaymentId { get; set; }
        public string Name { get; set; }
        public DateTime  Date { get; set; }
         
        public ICollection<Order> orders { get; set; }


    }
}
