using AutoMapper;
using CodePulse.API.Models.DTO.BlogPostDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public BlogPostsController(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto createBlogPostRequest)
        {
            var blogPostDomain = _mapper.Map<BlogPost>(createBlogPostRequest);

            blogPostDomain = await _blogPostRepository.CreateAsync(blogPostDomain);

            if (blogPostDomain is null)
            {
                return BadRequest(ModelState);
            }

            return Ok(blogPostDomain);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();
            return Ok(blogPosts);
        }
    }
}
