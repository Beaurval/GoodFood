using goodfood_user.Entities;
using goodfood_user.Models.Address;
using goodfood_user.Repositories.Interfaces;

namespace goodfood_user.Services.Interfaces
{
    public interface IAddressService
    {
        public Task<ICollection<GetAddressModel>> GetAddressesFromUserAsync(int idUser);
        public Task<GetAddressModel> GetAddressAsync(int idAddress);
        public Task<GetAddressModel> AddAddressToUserAsync(CreateAddressModel addressModel, int idUser);
        public void UpdateAddress(UpdateAddressModel addressModel);
        public Task DeleteUserAddress(int idAddress);
        public Task<bool> AddressExist(int idAddress);
    }
}
