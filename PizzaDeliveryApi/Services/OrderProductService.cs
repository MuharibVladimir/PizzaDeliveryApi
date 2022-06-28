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
        private readonly ILogger<IOrderProductService> _logger;

        public OrderProductService(IOrderProductRepository orderProducts, IMapper mapper, ILogger<IOrderProductService> logger)
        {
            _orderProducts = orderProducts; 
            _mapper = mapper;
            _logger = logger; 
        }

        public async Task DeleteOrderProductByIdAsync(int id)
        {
            var existingOrderProduct = await _orderProducts.GetOrderProductByIdAsync(id);

            if (existingOrderProduct != null)
            {
                await _orderProducts.DeleteOrderProductByIdAsync(existingOrderProduct);
            }
            else
            {
                _logger.LogError($"There is no ordered product with defined id = {id}");
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

            _logger.LogInformation("New ordered product was successfully created");

            return orderProduct;
        }

        public async Task<OrderProduct> EditOrderProductByIdAsync(int id, OrderProductDTO orderProductDto)
        {
            var orderProduct = await _orderProducts.EditOrderProductByIdAsync(id, _mapper.Map<OrderProduct>(orderProductDto));

            _logger.LogInformation("New ordered product was successfully updated");

            return orderProduct;
        }
    }
}
