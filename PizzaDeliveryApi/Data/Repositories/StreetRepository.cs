using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class StreetRepository: IStreetRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<IStreetRepository> _logger;

        public StreetRepository(DataContext context, ILogger<IStreetRepository> logger)
        {
            _context = context;
            _logger = logger;   
        }

        public async Task<Street> CreateStreetAsync(Street street)
        {
            _context.Streets.Add(street);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Street was successfully added");

            return street;
        }

        public async Task<List<Street>> GetAllStreetsAsync()
        {
            return await _context.Streets.ToListAsync();
        }

        public async Task<Street> GetStreetByIdAsync(int id)
        {
            var street = await _context.Streets.FirstOrDefaultAsync(street => street.Id == id);

            if (street == null)
            {
                _logger.LogError($"Street with id = {id} is not found");
            }

            return street;
        }

        public async Task<Street> EditStreetByIdAsync(int id, Street street)
        {
            _context.Entry(street).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Street was successfully updated");

            return street;
        }

        public async Task DeleteStreetByIdAsync(int id)
        {
            var street = await _context.Streets.FindAsync(id);

            if (street != null)
            {
                _context.Streets.Remove(street);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Street was successfully deleted");
            }
            else
            {
                _logger.LogError($"Street with id = {id} is not found");
            }
        }
    }
}
