using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Interfaces
{
    public interface IPaymentTypeRepository
    {
        Task<List<PaymentType>> GetAllPaymentTypesAsync();
        Task<PaymentType> GetPaymentTypeByIdAsync(int id);
        Task<PaymentType> CreatePaymentTypeAsync(PaymentType paymentType);

        Task<PaymentType> EditPaymentTypeByIdAsync(int id, PaymentType paymentType);
        Task DeletePaymentTypeByIdAsync(int id);
    }
}
