using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApi.Data.Models
{    public class PaymentType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you should write a name of payment type")]
        public string Name { get; set; } = null!;
        public virtual List<Order>? Orders { get; set; }
    }
}
