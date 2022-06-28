using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApi.Data.Models
{
    public class Street
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you should write a name of street")]
        public string Name { get; set; } = null!;
        public virtual List<Address>? Addresses { get; set; } 
    }
}
