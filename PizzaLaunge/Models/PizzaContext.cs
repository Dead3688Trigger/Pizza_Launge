using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {

        }
        public DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public DbSet<ORDER> ORDERs { get; set; }
        public DbSet<PAYMENT> PAYMENTs { get; set; }
        public DbSet<PIZZA> PIZZAs { get; set; }
        public DbSet<TOPPING> TOPPINGS { get; set; }

    }
}
