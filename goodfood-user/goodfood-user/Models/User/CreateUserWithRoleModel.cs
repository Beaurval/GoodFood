namespace goodfood_user.Models.User
{
    public class CreateUserWithRoleModel
    {
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Uuid { get; set; }
        public string PhoneNumber { get; set; }
    }
}
