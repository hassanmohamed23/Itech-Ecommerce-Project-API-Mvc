using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string  OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice  { get; set; }
        public  int ShipperId  { get; set; }
        public string UserPhone { get; set; }
        public string UserCity { get; set; }
        public string UserAddress { get; set; }
        public int ZIP { get; set; }
        public int PaymentId { get; set; }


        public User user { get; set; }
        public PaymentWay paymentWay { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
    }
}
