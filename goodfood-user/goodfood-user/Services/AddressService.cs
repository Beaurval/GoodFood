using AutoMapper;
using goodfood_user.Entities;
using goodfood_user.Models.Address;
using goodfood_user.Repositories.Interfaces;
using goodfood_user.Services.Interfaces;

namespace goodfood_user.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetAddressModel>> GetAddressesFromUserAsync(int idUser)
        {
            List<Address> addresses = (await _addressRepository.GetAddressesFromUser(idUser)).ToList();

            return _mapper.Map<ICollection<GetAddressModel>>(addresses);
        }

        public async Task<GetAddressModel> GetAddressAsync(int idAddress)
        {
            Address addresses = await _addressRepository.GetAddress(idAddress);

            return _mapper.Map<GetAddressModel>(addresses);
        }

        public async Task<GetAddressModel> AddAddressToUserAsync(CreateAddressModel addressModel, int idUser)
        {
            Address address = _mapper.Map<Address>(addressModel);
            address.LastUpdate = DateTime.Now;

            await _addressRepository.AddAddress(address);
            return _mapper.Map<GetAddressModel>(address);
        }

        public void UpdateAddress(UpdateAddressModel addressModel)
        {
            Address address = _mapper.Map<Address>(addressModel);
            address.LastUpdate = DateTime.Now;

            _addressRepository.UpdateAddress(address);
        }

        public async Task DeleteUserAddress(int idAddress)
        {
            _addressRepository.DeleteUserAddress(await _addressRepository.GetAddress(idAddress));
        }

        public async Task<bool> AddressExist(int idAddress) => await GetAddressAsync(idAddress) != null;
    }
}
