namespace goodfood_user.Models.Address
{
    public class CreateAddressModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
