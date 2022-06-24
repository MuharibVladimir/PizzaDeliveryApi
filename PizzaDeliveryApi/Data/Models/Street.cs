namespace PizzaDeliveryApi.Data.Models
{
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual List<Address>? Addresses { get; set; } 
    }
}
