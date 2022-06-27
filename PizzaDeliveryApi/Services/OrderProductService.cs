using AutoMapper;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Data.DtoModels;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services.Interfaces;

namespace PizzaDeliveryApi.Services
{
     public class OrderProductService: IOrderProductService
    {
        private readonly IOrderProductRepository _orderProducts;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public OrderProductService(IOrderProductRepository orderProducts, IMapper mapper, DataContext context)
        {
            _orderProducts = orderProducts; 
            _mapper = mapper;   
            _context = context; 
        }

        public async Task DeleteOrderProductByIdAsync(int id)
        {
            var existingOrderProduct = await _orderProducts.GetOrderProductByIdAsync(id);

            if (existingOrderProduct != null)
            {
                await _orderProducts.DeleteOrderProductByIdAsync(existingOrderProduct);
            }
        }

        public async Task<List<OrderProduct>> GetAllOrderProductsAsync()
        {
            return await _orderProducts.GetAllOrderProductsAsync();
        }

        public async Task<OrderProduct> GetOrderProductByIdAsync(int id)
        {
            return await _orderProducts.GetOrderProductByIdAsync(id);
        }

        public async Task<OrderProduct> CreateOrderProductAsync(OrderProductDTO orderProductDto)
        {
            var orderProduct = _mapper.Map<OrderProduct>(orderProductDto);

            await _orderProducts.CreateOrderProductAsync(orderProduct);
            await _context.SaveChangesAsync();

            return orderProduct;
        }

        public async Task<OrderProduct> EditOrderProductByIdAsync(int id, OrderProductDTO orderProductDto)
        {
            var orderProduct = await _orderProducts.EditOrderProductByIdAsync(id, _mapper.Map<OrderProduct>(orderProductDto));
            await _context.SaveChangesAsync();

            return orderProduct;
        }
    }
}
