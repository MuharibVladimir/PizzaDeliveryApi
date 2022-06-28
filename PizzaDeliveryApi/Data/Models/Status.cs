using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApi.Data.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you should write a name of status")]
        public string Name { get; set; } = null!;
        public virtual List<Order>? Orders { get; set; }
    }
}
