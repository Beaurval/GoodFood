using FluentAssertions;
using goodfood_provider.Entities;
using goodfood_provider.Models;
using goodfood_provider.Repositories;
using goodfood_provider.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace goodfood_provider_test
{
    public class DeleteProvider
    {

        private readonly ProviderContext context;



        public DeleteProvider()
        {
            context = new ProviderContext(new DbContextOptionsBuilder<ProviderContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
        }


        [Fact]
        public async void ShouldDeleteAProvider()
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
            providerRepository.DeleteProvider(provider.Id);
            await context.SaveChangesAsync();

            var result = await context.Providers.FirstOrDefaultAsync(p => p.Id == provider2.Id);
            // Assert
            Assert.Equal(1, await context.Providers.CountAsync());

            result.Id.Should().Be(provider2.Id);


        }
        [Fact]
        public async void ShouldThrowException()
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
            Func<Task> act = async () => { await providerRepository.DeleteProvider(3); };
            await context.SaveChangesAsync();

            // Assert
            await act.Should().ThrowAsync<Exception>();

        }
    }
}
