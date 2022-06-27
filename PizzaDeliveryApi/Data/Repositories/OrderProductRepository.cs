using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class OrderProductRepository: IOrderProductRepository
    {
        private readonly DataContext _context;

        public OrderProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<OrderProduct> CreateOrderProductAsync(OrderProduct orderProduct)
        {
            _context.OrderProducts.Add(orderProduct);
            await _context.SaveChangesAsync();

            return orderProduct;
        }

        public async Task<List<OrderProduct>> GetAllOrderProductsAsync()
        {
            return await _context.OrderProducts.ToListAsync();
        }

        public async Task<OrderProduct> GetOrderProductByIdAsync(int id)
        {
            var orderProduct = await _context.OrderProducts.FirstOrDefaultAsync(orderProduct => orderProduct.Id == id);

            return orderProduct;
        }

        public async Task<OrderProduct> EditOrderProductByIdAsync(int id, OrderProduct orderProduct)
        {
            _context.Entry(orderProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return orderProduct;
        }

        public async Task DeleteOrderProductByIdAsync(OrderProduct orderProduct)
        { 
                _context.OrderProducts.Remove(orderProduct);
                await _context.SaveChangesAsync();
        }
    }
}
