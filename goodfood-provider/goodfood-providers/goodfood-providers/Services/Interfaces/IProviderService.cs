using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using goodfood_provider.Entities;
using goodfood_provider.Models;

namespace goodfood_provider.Services.Interfaces
{
    public interface IProviderService
    {
        public Task<ICollection<Provider>> GetAllProviderAsync();
        public Task<Provider> GetProviderByIdAsync(int id);
        public Task<Provider> CreateProviderAsync(ProviderModel providerModel);
        public Task UpdateProviderAsync(ProviderModel providerModel);
        public void DeleteProviderAsync(int id);
    }
}
