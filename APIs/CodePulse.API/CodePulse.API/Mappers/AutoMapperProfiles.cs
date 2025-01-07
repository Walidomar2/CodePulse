using AutoMapper;
using CodePulse.API.Models.DTO.BlogPostDTOs;
using CodePulse.API.Models.DTO.CategoryDTOs;
using CodePulse.API.Models.DTO.ImagesDtos;

namespace CodePulse.API.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CreateCategoryRequestDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();    
            CreateMap<Category, UpdateCategoryRequestDto>().ReverseMap();

            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<BlogPost, CreateBlogPostRequestDto>().ReverseMap();

            CreateMap<BlogImage, BlogImageDto>().ReverseMap();  
        
        }
        
    }
}
