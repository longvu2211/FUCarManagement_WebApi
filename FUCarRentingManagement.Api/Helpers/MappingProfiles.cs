using AutoMapper;
using FUCarRentingManagement.Api.Dtos;
using FUCarRentingManagement.Domain.Entities;

namespace FUCarRentingManagement.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
            CreateMap<CarInformation, CarInformationDto>().ReverseMap();
        }
    }
}
