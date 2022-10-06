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
    public class CreateProvider
    {

        private readonly  ProviderContext context;



        public CreateProvider()
        {
            context = new ProviderContext(new DbContextOptionsBuilder<ProviderContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
        }


        [Fact]
        public async void ShouldCreateAProvider()
        {
            //arrange
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
            var providerModel = new ProviderModel()
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

            //act
            ProviderRepository providerRepository = new ProviderRepository(context);
            await providerRepository.CreateProvider(providerModel);
            await context.SaveChangesAsync();
            var result = await context.Providers.FirstOrDefaultAsync(p => p.Id == provider.Id);

            //assert
            result.Id.Should().Be(provider.Id);


        }
    }
}