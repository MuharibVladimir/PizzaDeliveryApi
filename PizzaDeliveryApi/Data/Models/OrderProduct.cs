using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaDeliveryApi.Data.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }    
        public int ProductId { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
