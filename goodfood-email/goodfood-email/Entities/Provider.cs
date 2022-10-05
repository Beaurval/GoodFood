namespace goodfood_email.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; }
        public string Cp { get; set; }
        public string City { get; set; }
        public string Informations { get; set; }
        public byte[]? ProviderImage { get; set; }
        public bool IsOpen { get; set; }

    }
}
