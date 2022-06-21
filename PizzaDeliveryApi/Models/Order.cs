namespace PizzaDeliveryApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        //public DateTime DeliveryDateTime { get; set; }
        //public DateTime OrdeRegistrationDateTime { get; set; }
        //public Customer? Customer { get; set; }
        //public int CustomerId { get; set; }
    }
}
