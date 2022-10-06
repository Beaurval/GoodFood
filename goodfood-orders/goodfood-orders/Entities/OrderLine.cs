using Newtonsoft.Json;

namespace goodfood_orders.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
