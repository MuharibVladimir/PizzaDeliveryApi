using PizzaDeliveryApi.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApi.Data.DtoModels
{
    public class AddressDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You should write the house number")]
        public int House { get; set; }
        public int? Building { get; set; }
        public int? Flat { get; set; }
        public int? Entrance { get; set; }
        public int? Floor { get; set; }

        [Required(ErrorMessage = "You should write the street id number")]
        public int StreetId { get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}
