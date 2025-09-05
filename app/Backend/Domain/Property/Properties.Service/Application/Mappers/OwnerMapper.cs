using AutoMapper;
using Properties.Service.Application.Dtos;
using Properties.Service.Domain.Entities;
using Properties.Service.Infrastructure.Persistence.Extensions;

namespace Properties.Service.Application.Mappers
{   
    public class OwnerMapper : Profile
    {
        public OwnerMapper()
        {
            CreateMap<Owner, OwnerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

            CreateMap<OwnerForCreationDto, Owner>();
            CreateMap<OwnerForUpdateDto, Owner>();
            CreateMap<Owner, OwnerForUpdateDto>();
        }
    }
}
