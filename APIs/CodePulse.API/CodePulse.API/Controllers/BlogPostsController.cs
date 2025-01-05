using AutoMapper;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO.BlogPostDTOs;
using CodePulse.API.Models.DTO.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public BlogPostsController(IBlogPostRepository blogPostRepository,
                                    IMapper mapper,
                                    ICategoryRepository categoryRepository)
        {
            _blogPostRepository = blogPostRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto createBlogPostRequest)
        {
            var blogPostDomain = await CreateBlogPostMapping(createBlogPostRequest);    

            blogPostDomain = await _blogPostRepository.CreateAsync(blogPostDomain);

            if (blogPostDomain is null)
            {
                return BadRequest(ModelState);
            }

            return Ok(_mapper.Map<BlogPostDto>(blogPostDomain));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();
            return Ok(_mapper.Map<List<BlogPostDto>>(blogPosts));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBlogPostById([FromRoute] Guid id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);

            if(blogPost is null)
            {
                return NotFound();  
            }

            return Ok(_mapper.Map<BlogPostDto>(blogPost));
        }

        private async Task<BlogPost> CreateBlogPostMapping(CreateBlogPostRequestDto dtoModel)
        {
            var blogPost = new BlogPost
            {
                Title = dtoModel.Title,
                ShortDescription = dtoModel.ShortDescription,
                Content = dtoModel.Content,
                FeaturedImageUrl = dtoModel.FeaturedImageUrl,
                UrlHandle = dtoModel.UrlHandle,
                PublishedDate = dtoModel.PublishedDate,
                Author = dtoModel.Author,
                IsVisible = dtoModel.IsVisible,
                Categories = new List<Category>()
            };

            foreach (var categoryGuid in dtoModel.Categories)
            {
                var existingCategory = await _categoryRepository.GetByIdAsync(categoryGuid);

                if (existingCategory is not null)
                {
                    blogPost.Categories.Add(existingCategory);
                }
            }

            return blogPost;    
        }
    }
}
