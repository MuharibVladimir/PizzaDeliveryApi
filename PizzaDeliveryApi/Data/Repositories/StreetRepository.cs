using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class StreetRepository: IStreetRepository
    {
        private readonly DataContext _context;

        public StreetRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Street> CreateStreetAsync(Street street)
        {
            _context.Streets.Add(street);
            await _context.SaveChangesAsync();

            return street;
        }

        public async Task<List<Street>> GetAllStreetsAsync()
        {
            return await _context.Streets.ToListAsync();
        }

        public async Task<Street> GetStreetByIdAsync(int id)
        {
            var street = await _context.Streets.FirstOrDefaultAsync(street => street.Id == id);

            return street;
        }

        public async Task<Street> EditStreetByIdAsync(int id, Street street)
        {
            _context.Entry(street).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return street;
        }

        public async Task DeleteStreetByIdAsync(int id)
        {
            var street = await _context.Streets.FindAsync(id);

            if (street != null)
            {
                _context.Streets.Remove(street);
                await _context.SaveChangesAsync();
            }
        }
    }
}
