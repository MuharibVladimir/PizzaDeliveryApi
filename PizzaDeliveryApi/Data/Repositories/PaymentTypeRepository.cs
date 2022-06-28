using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class PaymentTypeRepository: IPaymentTypeRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<IPaymentTypeRepository> _logger;

        public PaymentTypeRepository(DataContext context, ILogger<IPaymentTypeRepository> logger)
        {
            _context = context;
            _logger = logger;   
        }

        public async Task<PaymentType> CreatePaymentTypeAsync(PaymentType paymentType)
        {
            _context.PaymentTypes.Add(paymentType);
            await _context.SaveChangesAsync();

            _logger.LogInformation("PaymentType was successfully added");

            return paymentType;
        }

        public async Task<List<PaymentType>> GetAllPaymentTypesAsync()
        {
            return await _context.PaymentTypes.ToListAsync();
        }

        public async Task<PaymentType> GetPaymentTypeByIdAsync(int id)
        {
            var paymentType = await _context.PaymentTypes.FirstOrDefaultAsync(paymentType => paymentType.Id == id);

            if (paymentType == null)
            {
                _logger.LogError($"PaymentType with id = {id} is not found");
            }

            return paymentType;
        }

        public async Task<PaymentType> EditPaymentTypeByIdAsync(int id, PaymentType paymentType)
        {
            _context.Entry(paymentType).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _logger.LogInformation("PaymentType was successfully updated");

            return paymentType;
        }

        public async Task DeletePaymentTypeByIdAsync(int id)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(id);

            if (paymentType != null)
            {
                _context.PaymentTypes.Remove(paymentType);
                await _context.SaveChangesAsync();

                _logger.LogInformation("PaymentType was successfully deleted");
            }
            else
            {
                _logger.LogError($"PaymentType with id = {id} is not found");
            }
        }
    }
}
