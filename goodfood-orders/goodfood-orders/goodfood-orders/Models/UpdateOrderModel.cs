namespace goodfood_orders.Models
{
    public class UpdateOrderModel
    {
        public int Id { get; set; }
        public double Tip { get; set; }
        public int RestaurantId { get; set; }
    }
}
