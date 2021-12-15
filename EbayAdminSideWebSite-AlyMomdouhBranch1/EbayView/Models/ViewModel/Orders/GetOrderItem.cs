namespace EbayView.Models.ViewModel.Orders
{
    public class GetOrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float price { get; set; }
        public int Discount { get; set; }
    }
}
