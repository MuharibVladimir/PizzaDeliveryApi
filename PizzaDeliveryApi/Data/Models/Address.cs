using System.Text.Json.Serialization;

namespace PizzaDeliveryApi.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int House { get; set; }
        public int? Building { get; set; }
        public int? Flat { get; set; }  
        public int? Entrance { get; set; }
        public int? Floor { get; set; }
        public int StreetId { get; set; }

        [JsonIgnore]
        public virtual Street Street { get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}
