﻿namespace PizzaDeliveryApi.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descripiton { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
