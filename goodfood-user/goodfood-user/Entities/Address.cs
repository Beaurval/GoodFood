namespace goodfood_user.Entities
{
    public class Address
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
        public User User { get; set; }
    }
}
