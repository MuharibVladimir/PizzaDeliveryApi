using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class PaymentTypeRepository: IPaymentTypeRepository
    {
        private readonly DataContext _context;

        public PaymentTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PaymentType> CreatePaymentTypeAsync(PaymentType paymentType)
        {
            _context.PaymentTypes.Add(paymentType);
            await _context.SaveChangesAsync();

            return paymentType;
        }

        public async Task<List<PaymentType>> GetAllPaymentTypesAsync()
        {
            return await _context.PaymentTypes.ToListAsync();
        }

        public async Task<PaymentType> GetPaymentTypeByIdAsync(int id)
        {
            var paymentType = await _context.PaymentTypes.FirstOrDefaultAsync(paymentType => paymentType.Id == id);

            return paymentType;
        }

        public async Task<PaymentType> EditPaymentTypeByIdAsync(int id, PaymentType paymentType)
        {
            _context.Entry(paymentType).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return paymentType;
        }

        public async Task DeletePaymentTypeByIdAsync(int id)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(id);

            if (paymentType != null)
            {
                _context.PaymentTypes.Remove(paymentType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
