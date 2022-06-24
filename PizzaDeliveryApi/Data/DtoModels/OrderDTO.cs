using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDeliveryApi.Data.DTOModels
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime? DeliveryEdgeDateTime { get; set; }
        public DateTime? OrderRegistrationDateTime { get; set; }
    }
}
