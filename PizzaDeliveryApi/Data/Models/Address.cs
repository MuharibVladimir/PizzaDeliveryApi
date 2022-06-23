namespace PizzaDeliveryApi.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int StreetId { get; set; }
        public int House { get; set; }
        public int? Building { get; set; }
        public int? Flat { get; set; }  
        public int? Entrance { get; set; }
        public int? Floor { get; set; }
    }
}
