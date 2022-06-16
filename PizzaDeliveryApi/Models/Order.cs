namespace PizzaDeliveryApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CourierId { get; set; }
        public int FoodId { get; set; }
        public string? Status { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public DateTime OrdeRegistrationDateTime { get; set; }
    }
}
