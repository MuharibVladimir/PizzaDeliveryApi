using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaDeliveryApi.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You should write the name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "You should write the last name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "You should write the phone number")]
        [Phone(ErrorMessage = "write a correct phone number")]
        public string PhoneNumber { get; set; } = null!;

        [EmailAddress(ErrorMessage = "write a correct email address")]
        public string? EmailAddress { get; set; }

        public virtual List<Order>? Orders { get; set; }

    }
}
