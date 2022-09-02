﻿using goodfood_user.Entities;
using goodfood_user.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace goodfood_user.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly UserContext _userContext;

        public AddressRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<ICollection<Address>> GetAddressesFromUser(int idUser) 
            => await _userContext.Addresses.Where(a => a.UserId == idUser).ToListAsync();

        public async Task<Address> GetAddress(int idAddress) 
            => (await _userContext.Addresses.FirstOrDefaultAsync(a => a.Id == idAddress))!;

        public async Task<Address> AddAddress(Address address)
        {
            await _userContext.Addresses.AddAsync(address);
            return address;
        }

        public void UpdateAddress(Address address)
        {
            _userContext.ChangeTracker.Clear();
            _userContext.Addresses.Update(address);
        }

        public void DeleteUserAddress(Address address)
        {
            _userContext.Addresses.Remove(address);
        }
    }
}
