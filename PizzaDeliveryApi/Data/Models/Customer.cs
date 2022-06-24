using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaDeliveryApi.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? EmailAddress { get; set; }

        //[JsonIgnore]
        public virtual List<Order>? Orders { get; set; }

    }
}
