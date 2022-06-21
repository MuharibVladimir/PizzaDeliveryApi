using PizzaDeliveryApi.Models;

namespace PizzaDeliveryApi.Services
{
    public class OrderService
    {
        static List<Order> Orders { get; }
        static int nextId = 3;
        static OrderService()
        {
        //    Orders = new List<Order>
        //{
        //    new Order { Id = 1, CustomerId = 5, /*CourierId = 1, FoodId = 2*/ Status = "In progress", DeliveryDateTime = DateTime.Now, OrdeRegistrationDateTime = DateTime.Today },
        //    new Order { Id = 2, CustomerId = 6, CourierId = 2, FoodId = 4, Status = "Delivered", DeliveryDateTime = DateTime.Now, OrdeRegistrationDateTime = DateTime.Today }
        //}; 
        }

        public static List<Order> GetAll() => Orders;

        public static Order? Get(int id) => Orders.FirstOrDefault(p => p.Id == id);

        public static void Add(Order order)
        {
            order.Id = nextId++;
            Orders.Add(order);
        }

        public static void Delete(int id)
        {
            var order = Get(id);
            if (order is null)
                return;

            Orders.Remove(order);
        }

        public static void Update(Order order)
        {
            var index = Orders.FindIndex(p => p.Id == order.Id);
            if (index == -1)
                return;

            Orders[index] = order;
        }
    }
}

