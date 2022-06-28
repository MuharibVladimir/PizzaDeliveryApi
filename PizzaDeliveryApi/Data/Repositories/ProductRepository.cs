using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<IProductRepository> _logger;

        public ProductRepository(DataContext context, ILogger<IProductRepository> logger)
        {
            _context = context;
            _logger = logger;   
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Product was successfully added");

            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                _logger.LogError($"Product with id = {id} is not found");
            }

            return product;
        }

        public async Task<Product> EditProductByIdAsync(int id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Product was successfully updated");

            return product;
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Product was successfully deleted");
            }
            else
            {
                _logger.LogError($"Product with id = {id} is not found");
            }
        }
    }
}
