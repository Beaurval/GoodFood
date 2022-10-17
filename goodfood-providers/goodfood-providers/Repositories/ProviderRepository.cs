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
            if (providerModel?.ProviderImage?.Length > 0)
            {
                using var ms = new MemoryStream();
                await providerModel.ProviderImage.CopyToAsync(ms);
                convertedImage = ms.ToArray();
            }
            Provider provider = new()
            {
                Id = providerModel.Id,
                Name = providerModel.Name,
                Address = providerModel.Address,
                City = providerModel.City,
                Cp = providerModel.Cp,
                Informations = providerModel.Informations,
                ProviderImage = convertedImage,
                IsOpen = providerModel.IsOpen,

            };
            await _providerContext.Providers.AddAsync(provider);
            return provider;
        }

        public async Task DeleteProvider(int idProvider)
        {
            _providerContext.Providers.Remove(await _providerContext.Providers.FirstOrDefaultAsync(p => p.Id  == idProvider));
        }

        public async Task<ICollection<Provider>> GetAllProvider()
        {
            return await _providerContext.Providers.ToListAsync();
        }

        public async Task<Provider> GetProviderById(int id)
        {
            return await _providerContext.Providers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProvider(ProviderModel providerModel)
        {
            Provider provider = await GetProviderById(providerModel.Id);
            provider.Id = providerModel.Id;
            provider.Name = providerModel.Name;
            provider.Address = providerModel.Address;
            provider.City = providerModel.City;
            provider.Cp = providerModel.Cp;
            provider.Informations = providerModel.Informations;
            provider.IsOpen = providerModel.IsOpen;

            if (providerModel?.ProviderImage?.Length > 0)
            {
                await using var ms = new MemoryStream();
                await providerModel.ProviderImage.CopyToAsync(ms);
                provider.ProviderImage = ms.ToArray();

            }

            _providerContext.Providers.Update(provider);

        }
    }
}
