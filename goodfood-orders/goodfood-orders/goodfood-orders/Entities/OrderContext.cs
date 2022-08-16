using Microsoft.EntityFrameworkCore;

namespace goodfood_orders.Entities
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = null!;
    }
}
