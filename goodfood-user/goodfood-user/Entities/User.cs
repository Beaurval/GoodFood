namespace goodfood_user.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool RegistrationValidated { get; set; }
        public string Uuid { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
