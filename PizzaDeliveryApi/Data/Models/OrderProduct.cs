using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDeliveryApi.Data.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int OrederId { get; set; }   
        public int ProductId { get; set; }   
    }
}
