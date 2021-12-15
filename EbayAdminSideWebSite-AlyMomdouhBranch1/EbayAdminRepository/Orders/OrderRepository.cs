namespace EbayAdminRepository.Orders
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderRepository : IOrderRepository
    {
        private readonly myDbContext _context;
        public OrderRepository(myDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddOrderAsync(Order Order)
        {
            await _context.Orders.AddAsync(Order);

            await _context.SaveChangesAsync();


            return Order.OrderId;
        }


        public async Task<int> DeleteOrderAsync(Order Order)
        {
            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();
            return Order.OrderId;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderDetailsAsync(int value)
        {
            return await _context.Orders
                .Include(o=>o.orderItems)
                .Where(c => c.OrderId == value).FirstOrDefaultAsync();
        }


        public async Task<int> UpdateOrderAsync(Order Order)
        {
            _context.Update(Order);
            await _context.SaveChangesAsync();
            return Order.OrderId;
        }
        
    }
}
