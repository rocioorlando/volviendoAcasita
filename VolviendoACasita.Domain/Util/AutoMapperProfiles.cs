using AutoMapper;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Domain.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<LostFoundForm, LostFoundFormDto>().ReverseMap();
            CreateMap<Pet, PetDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Province, ProvinceDto>().ReverseMap();
            CreateMap<Veterinary, VeterinaryDto>().ReverseMap();
            CreateMap<Archive, ArchiveDto>().ReverseMap();
            CreateMap<Breed, BreedDto>().ReverseMap();
            CreateMap<Species, SpeciesDto>().ReverseMap();

        }
    }
}
