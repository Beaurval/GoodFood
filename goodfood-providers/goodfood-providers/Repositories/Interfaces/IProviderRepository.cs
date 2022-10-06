using goodfood_provider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using goodfood_provider.Models;

namespace goodfood_provider.Repositories.Interfaces
{
    public interface IProviderRepository
    {
        public Task<ICollection<Provider>> GetAllProvider();
        public Task<Provider> GetProviderById(int id);
        public Task<Provider> CreateProvider(ProviderModel providerModel);
        public Task UpdateProvider(ProviderModel providertModel);
        public Task DeleteProvider(int idProvider);
    }
}
