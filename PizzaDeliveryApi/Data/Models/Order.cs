using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDeliveryApi.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public int CustomerId { get; set; }
        public int DeliveryAddressId { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryEdgeDateTime { get; set; }
        public DateTime OrderRegistrationDateTime { get; set; }

        //public Customer Customer { get; set; } = null!;
        //public int CustomerId { get; set; }
    }
}
