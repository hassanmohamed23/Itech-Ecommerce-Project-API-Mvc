using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Models.ViewModel.Orders
{
    public class GetOrderDetailsOutputModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public int ShipperId { get; set; }
        public string UserPhone { get; set; }
        public string UserCity { get; set; }
        public string UserAddress { get; set; }
        public string FistName { get; set; }
        public int ZIP { get; set; }
        public int PaymentId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
