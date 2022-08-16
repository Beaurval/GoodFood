namespace goodfood_orders.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public double Tip { get; set; }
        public double ServiceCharge { get; set; }
        public double ShippingCharge { get; set; }
    }
}
