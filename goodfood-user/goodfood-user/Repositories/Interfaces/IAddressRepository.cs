using goodfood_user.Entities;

namespace goodfood_user.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        public Task<ICollection<Address>> GetAddressesFromUser(int idUser);
        public Task<Address> GetAddress(int idAddress);
        public Task<Address> AddAddress(Address address);
        public void UpdateAddress(Address address);
        public void DeleteUserAddress(Address address);
    }
}
