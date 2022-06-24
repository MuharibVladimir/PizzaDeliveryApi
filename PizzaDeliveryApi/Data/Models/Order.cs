using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaDeliveryApi.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int StatusId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        public int PaymentTypeId { get; set; }

        [JsonIgnore]
        public virtual PaymentType PaymentType { get; set; }
        public int CustomerId { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        public int AddressId { get; set; }
        [JsonIgnore]
        public virtual Address Address { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime? DeliveryEdgeDateTime { get; set; }
        public DateTime? OrderRegistrationDateTime { get; set; }
    }
}
