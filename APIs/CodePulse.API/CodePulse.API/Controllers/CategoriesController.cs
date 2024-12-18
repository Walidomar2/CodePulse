using AutoMapper;
using CodePulse.API.Models.DTO.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto requestModel)
        {
            var domainModel = _mapper.Map<Category>(requestModel);
            domainModel = await _categoryRepository.CreateAsync(domainModel);

            if (domainModel is null)
            {
                return BadRequest(ModelState);
            }

            return Ok(domainModel); 
        }
    }
}
