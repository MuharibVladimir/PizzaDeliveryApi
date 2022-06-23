using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }  
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }    
        public DbSet<Status> Statuses { get; set; } 
        
    }
}
