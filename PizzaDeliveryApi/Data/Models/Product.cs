using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDeliveryApi.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you should write a name of product")]
        public string Name { get; set; } = null!;   
        public string? Descripiton { get; set; }

        [Required]
        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }
        public virtual List<OrderProduct>? OrderProducts { get; set; }
    }
}
