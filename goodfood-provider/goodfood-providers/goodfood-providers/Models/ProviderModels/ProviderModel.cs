using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goodfood_provider.Models
{
    public class ProviderModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; }
        public string Cp { get; set; }
        public string City { get; set; }
        public string Informations { get; set; }
        public IFormFile ProviderImage { get; set; } = null!;
        public bool IsOpen { get; set; }

    }
}
