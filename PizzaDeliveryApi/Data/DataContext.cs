using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Models;

namespace PizzaDeliveryApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
