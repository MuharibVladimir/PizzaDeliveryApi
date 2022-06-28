using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaDeliveryApi.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you should write status id")]
        public int StatusId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }

        [Required(ErrorMessage = "you should write payment type id")]
        public int PaymentTypeId { get; set; }

        [JsonIgnore]
        public virtual PaymentType PaymentType { get; set; }

        [Required(ErrorMessage = "you should write customer id")]
        public int CustomerId { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        [Required(ErrorMessage = "you should write address id")]
        public int AddressId { get; set; }

        [JsonIgnore]
        public virtual Address Address { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime? DeliveryEdgeDateTime { get; set; }
        public DateTime? OrderRegistrationDateTime { get; set; }
    }
}
