using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class StatusRepository: IStatusRepository
    {
        private readonly DataContext _context;

        public StatusRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Status> CreateStatusAsync(Status status)
        {
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            return status;
        }

        public async Task<List<Status>> GetAllStatusesAsync()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(status => status.Id == id);

            return status;
        }

        public async Task<Status> EditStatusByIdAsync(int id, Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return status;
        }

        public async Task DeleteStatusByIdAsync(int id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status != null)
            {
                _context.Statuses.Remove(status);
                await _context.SaveChangesAsync();
            }
        }
    }
}
