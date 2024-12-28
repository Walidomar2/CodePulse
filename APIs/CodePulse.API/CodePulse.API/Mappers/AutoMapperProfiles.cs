using AutoMapper;
using CodePulse.API.Models.DTO.BlogPostDTOs;
using CodePulse.API.Models.DTO.CategoryDTOs;

namespace CodePulse.API.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CreateCategoryRequestDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();    
            CreateMap<Category, UpdateCategoryRequestDto>().ReverseMap();

            CreateMap<BlogPost,CreateBlogPostRequestDto>().ReverseMap();    
        }
        
    }
}
