namespace goodfood_orders.Models
{
    public class CreateOrderModel
    {
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public double Tip { get; set; }
    }
}
