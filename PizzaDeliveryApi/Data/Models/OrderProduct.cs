using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaDeliveryApi.Data.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you should write a quantity of ordered product")]
        [Range(1,50, ErrorMessage = "you can't deliver this quantity of product")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "you should write an order id")]
        public int OrderId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }

        [Required(ErrorMessage = "you should write a product id")]
        public int ProductId { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
