using AutoMapper;
using goodfood_user.Entities;
using goodfood_user.Models.Address;
using goodfood_user.Models.Role;

namespace goodfood_user.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<GetAddressModel,Address>();
            CreateMap<Address, GetAddressModel>();
            CreateMap<CreateAddressModel, Address>();
            CreateMap<UpdateAddressModel, Address>();
        }
    }
}
