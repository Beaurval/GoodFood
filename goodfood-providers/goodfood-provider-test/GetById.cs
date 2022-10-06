using FluentAssertions;
using goodfood_provider.Entities;
using goodfood_provider.Models;
using goodfood_provider.Repositories;
using goodfood_provider.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;


namespace goodfood_provider_test
{
    public class GetById
    {
        private readonly ProviderContext context;

        public GetById()
        {
            context = new ProviderContext(new DbContextOptionsBuilder<ProviderContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
        }


        [Fact]
        public async void ShouldGetProviderById()
        {
            // Arrange
            var provider = new Provider()
            {
                Id = 1,
                Name = "Nom",
                Address = "adresse",
                City = "ville",
                Cp = "code postal",
                Informations = "informations",
                ProviderImage = null,
                IsOpen = false,

            }; 
            var provider2 = new Provider()
            {
                Id = 2,
                Name = "Nom",
                Address = "adresse",
                City = "ville",
                Cp = "code postal",
                Informations = "informations",
                ProviderImage = null,
                IsOpen = false,

            };
            await context.Providers.AddAsync(provider);
            await context.Providers.AddAsync(provider2);
            await context.SaveChangesAsync();

            // Act
            ProviderRepository providerRepository = new ProviderRepository(context);

            Provider actual = await providerRepository.GetProviderById(provider.Id);
            Provider expected = await context.Providers.FirstOrDefaultAsync(p => p.Id == provider.Id);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
