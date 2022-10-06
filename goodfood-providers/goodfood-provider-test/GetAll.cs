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
    public class GetAll
    {
        private readonly ProviderContext context;

        public GetAll()
        {
            context = new ProviderContext(new DbContextOptionsBuilder<ProviderContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
        }


        [Fact]
        public async void ShouldGetAllProviders()
        {
            // Arrange
            IEnumerable<Provider> expected = new List<Provider>
            {
                new()
                {
                    Id = 1,
                    Name = "Nom",
                    Address = "adresse",
                    City = "ville",
                    Cp = "code postal",
                    Informations = "informations",
                    ProviderImage = null,
                    IsOpen = false,
                },
                new()
                {
                    Id = 2,
                    Name = "Nom",
                    Address = "adresse",
                    City = "ville",
                    Cp = "code postal",
                    Informations = "informations",
                    ProviderImage = null,
                    IsOpen = false,
                }
            };
            await context.Providers.AddRangeAsync(expected);

            await context.SaveChangesAsync();

            // Act
            ProviderRepository providerRepository = new ProviderRepository(context);

            IEnumerable<Provider> actual = await providerRepository.GetAllProvider();

            // Assert
            Assert.Equal(expected, actual);


        }

        [Fact]
        public async void ShouldGetAllEmpty()
        {
            // Arrange
            IEnumerable<Provider> expected = new List<Provider>{};
            // ??
            //await context.Providers.AddRangeAsync(expected);
            //await context.SaveChangesAsync();

            // Act
            ProviderRepository providerRepository = new ProviderRepository(context);

            IEnumerable<Provider> actual = await providerRepository.GetAllProvider();

            // Assert
            Assert.Equal(expected, actual);


        }

    }
}
