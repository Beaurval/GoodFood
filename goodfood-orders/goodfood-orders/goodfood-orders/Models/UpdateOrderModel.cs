namespace goodfood_orders.Models
{
    public class UpdateOrderModel
    {
        public int Id { get; set; }
        public double Tip { get; set; }
        public double ServiceCharge { get; set; }
        public double ShippingCharge { get; set; }
    }
}
