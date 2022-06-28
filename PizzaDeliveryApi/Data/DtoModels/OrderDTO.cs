using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDeliveryApi.Data.DTOModels
{
    public class OrderDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you should write status id")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "you should write payment type id")]
        public int PaymentTypeId { get; set; }

        [Required(ErrorMessage = "you should write customer id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "you should write address id")]
        public int AddressId { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime? DeliveryEdgeDateTime { get; set; }
        public DateTime? OrderRegistrationDateTime { get; set; }
    }
}
