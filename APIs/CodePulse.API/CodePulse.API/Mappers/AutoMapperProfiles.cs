using AutoMapper;
using CodePulse.API.Models.DTO.CategoryDTOs;

namespace CodePulse.API.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CreateCategoryRequestDto>().ReverseMap();
        }
        
    }
}
