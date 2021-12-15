namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrderRepository
    {
        Task<int> AddOrderAsync(Order Order);
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderDetailsAsync(int value);
        Task<int> UpdateOrderAsync(Order Order);
        Task<int> DeleteOrderAsync(Order Order);
    }
}
