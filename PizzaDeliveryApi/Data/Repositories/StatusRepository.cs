using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class StatusRepository: IStatusRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<IStatusRepository> _logger;

        public StatusRepository(DataContext context, ILogger<IStatusRepository> logger)
        {
            _context = context;
            _logger = logger;   
        }

        public async Task<Status> CreateStatusAsync(Status status)
        {
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Status was successfully added");

            return status;
        }

        public async Task<List<Status>> GetAllStatusesAsync()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(status => status.Id == id);

            if (status == null)
            {
                _logger.LogError($"Status with id = {id} is not found");
            }

            return status;
        }

        public async Task<Status> EditStatusByIdAsync(int id, Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Status was successfully updated");

            return status;
        }

        public async Task DeleteStatusByIdAsync(int id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status != null)
            {
                _context.Statuses.Remove(status);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Status was successfully deleted");
            }
            else
            {
                _logger.LogError($"Status with id = {id} is not found");
            }
        }
    }
}
