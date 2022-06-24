using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Data.DTOModels;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApi.Services
{
    public class OrderService: IOrderService
    {
        private readonly ICustomerRepository _customers;
        private readonly IAddressRepository _addresses;
        private readonly IStatusRepository _statuses;
        private readonly IPaymentTypeRepository _payments;
        private readonly IOrderRepository _orders;
        private readonly DataContext _context;
        public OrderService(IOrderRepository orders, ICustomerRepository customers, IAddressRepository addresses, IStatusRepository statuses,
            IPaymentTypeRepository payments, DataContext context)
        {
            _orders = orders;    
            _customers = customers;
            _addresses = addresses; 
            _statuses = statuses;   
            _payments = payments;   
            _context = context; 
        }

        public async Task MakeOrder(OrderDTO orderDto)
        {
            Customer customer = await _customers.GetCustomerByIdAsync(orderDto.CustomerId);
            Address address = await _addresses.GetAddressByIdAsync(orderDto.AddressId);
            PaymentType paymentType = await _payments.GetPaymentTypeByIdAsync(orderDto.PaymentTypeId);
            Status status = await _statuses.GetStatusByIdAsync(orderDto.StatusId);

            // валидация
            if (customer == null)
                throw new ValidationException("Customer is not found");

            Order order = new Order
            {
                OrderRegistrationDateTime = orderDto.DeliveryEdgeDateTime,
                DeliveryEdgeDateTime = orderDto.DeliveryEdgeDateTime,
                Customer = customer,
                Status = status,
                PaymentType = paymentType,
                Address = address,
                TotalPrice = orderDto.TotalPrice,
                PaymentTypeId = orderDto.PaymentTypeId,
                AddressId = orderDto.AddressId, 
                StatusId = orderDto.StatusId,
                CustomerId = orderDto.CustomerId
            };

                await _orders.CreateOrderAsync(order);
                await _context.SaveChangesAsync();


     
          
        }

        public async Task DeleteOrderByIdAsync(int id)
        {

           await  _orders.DeleteOrderByIdAsync(id);
        }

    }
}

