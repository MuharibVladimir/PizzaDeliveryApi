﻿namespace PizzaDeliveryApi.Data.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual List<Order>? Orders { get; set; }
    }
}
