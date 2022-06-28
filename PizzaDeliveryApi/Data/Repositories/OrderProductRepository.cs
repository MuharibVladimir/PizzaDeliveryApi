using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class OrderProductRepository: IOrderProductRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<IOrderProductRepository> _logger;

        public OrderProductRepository(DataContext context, ILogger<IOrderProductRepository> logger)
        {
            _context = context;
            _logger = logger;   
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
          
            if (orderProduct == null)
            {
                _logger.LogError($"The ordered product with id = {id} is not found");
            }

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

            _logger.LogInformation($"The address was successfully deleted");
        }
    }
}
