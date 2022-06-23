using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDeliveryApi.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;   
        public string? Descripiton { get; set; }

        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }
    }
}
