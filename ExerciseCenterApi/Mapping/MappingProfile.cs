using AutoMapper;
using ExerciseCenter_API.Dtos;
using ExerciseCenter_API.Models.ServicesModels;

namespace ExerciseCenter_API.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<ServiceCreateDto, Service>();
            CreateMap<ServiceUpdateDto, Service>();
        }
    }
}
