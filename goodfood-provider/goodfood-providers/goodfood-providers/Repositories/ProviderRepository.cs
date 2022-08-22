using goodfood_provider.Entities;
using goodfood_provider.Models;
using goodfood_provider.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace goodfood_provider.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ProviderContext _providerContext;

        public ProviderRepository(ProviderContext providerContext)
        {
            _providerContext = providerContext;
        }

        public async Task<Provider> CreateProvider(ProviderModel providerModel)
        {
            byte[] convertedImage = null!;
            if (providerModel.ProviderImage.Length > 0)
            {
                using var ms = new MemoryStream();
                await providerModel.ProviderImage.CopyToAsync(ms);
                convertedImage = ms.ToArray();
            }
            Provider provider = new()
            {
                Id = providerModel.Id,
                Name = providerModel.Name,
                Address = providerModel.Adress,
                City = providerModel.City,
                Cp = providerModel.Cp,
                Informations = providerModel.Informations,
                IsOpen = providerModel.IsOpen,

            };
            await _providerContext.Providers.AddAsync(provider);
            return provider;
        }

        public async void DeleteProvider(int idProvider)
        {
            Provider provider = await GetProviderById(idProvider);
            _providerContext.Remove(provider);
        }

        public async Task<ICollection<Provider>> GetAllProvider()
        {
            return await _providerContext.Providers.ToListAsync();
        }

        public Task<Provider> GetProviderById(int id)
        {
            return _providerContext.Providers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProvider(ProviderModel providerModel)
        {
            Provider provider = await GetProviderById(providerModel.Id);
            provider.Id = providerModel.Id;
            provider.Name = providerModel.Name;
            provider.Address = providerModel.Adress;
            provider.City = providerModel.City;
            provider.Cp = providerModel.Cp;
            provider.Informations = providerModel.Informations;
            provider.IsOpen = providerModel.IsOpen;

            if (providerModel.ProviderImage.Length > 0)
            {
                using var ms = new MemoryStream();
                await providerModel.ProviderImage.CopyToAsync(ms);
                provider.ProviderImage = ms.ToArray();
            }

            _providerContext.Providers.Update(provider);

        }
    }
}
