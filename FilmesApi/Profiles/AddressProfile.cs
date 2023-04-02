using AutoMapper;
using MoviesApi.Data.Dtos.Address;
using MoviesApi.Data.Dtos.Movies;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<Address, ReadAddressDto>();
        CreateMap<UpdateAddressDto, Address>();
        CreateMap<Address, UpdateAddressDto>();
    }
}
