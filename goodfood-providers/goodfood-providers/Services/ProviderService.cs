using goodfood_provider.Entities;
using goodfood_provider.Models;
using goodfood_provider.Repositories.Interfaces;
using goodfood_provider.Services.Interfaces;
using System;


namespace goodfood_provider.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<ICollection<Provider>> GetAllProviderAsync()
        {
            return await _providerRepository.GetAllProvider();
        }

        public async Task<Provider> GetProviderByIdAsync(int id)
        {
            return await _providerRepository.GetProviderById(id);
        }

        public async Task<Provider> CreateProviderAsync(ProviderModel providerModel)
        {
            return await _providerRepository.CreateProvider(providerModel);
        }

        public async Task UpdateProviderAsync(ProviderModel providerModel)
        {
            await _providerRepository.UpdateProvider(providerModel);
        }

        public void DeleteProviderAsync(int id)
        {
            _providerRepository.DeleteProvider(id);
        }
    }
}
