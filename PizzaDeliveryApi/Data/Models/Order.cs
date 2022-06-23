using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDeliveryApi.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }  
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }    
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryEdgeDateTime { get; set; }
        public DateTime OrderRegistrationDateTime { get; set; }

        

        //public Customer Customer { get; set; } = null!;
        //public int CustomerId { get; set; }
    }
}
