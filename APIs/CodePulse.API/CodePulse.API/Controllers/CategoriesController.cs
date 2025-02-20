﻿using AutoMapper;
using CodePulse.API.Models.DTO.CategoryDTOs;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            return Ok(categoriesDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var categoryDomain = await _categoryRepository.GetByIdAsync(id);

            if (categoryDomain is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryDto>(categoryDomain));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id,[FromBody] UpdateCategoryRequestDto updateCategoryModel)
        {
            var categoryDomain = _mapper.Map<Category>(updateCategoryModel);

            categoryDomain =  await _categoryRepository.UpdateAsync(id, categoryDomain);

            if(categoryDomain is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryDto>(categoryDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var categoryDomain = await _categoryRepository.DeleteAsync(id);

            if(categoryDomain is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryDto>(categoryDomain));
        }
    }
}
