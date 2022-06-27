using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);

            return order;
        }

        public async Task<Order> EditOrderByIdAsync(int id, Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task DeleteOrderByIdAsync(Order order)
        {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
        }
    }
}
