using Newtonsoft.Json;

namespace goodfood_orders.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double Tip { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderLine> Lines { get; set; } = null!;
    }
}
