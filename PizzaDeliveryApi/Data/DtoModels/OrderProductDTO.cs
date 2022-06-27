using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDeliveryApi.Data.DtoModels
{
    public class OrderProductDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
