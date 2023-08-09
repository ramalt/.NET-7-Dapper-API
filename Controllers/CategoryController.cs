using Estate.Api.Models.DapperContext.Dtos.CategoryDtos;
using Estate.Api.Repository.CategoryRepository;
using Microsoft.AspNetCore.Mvc;

namespace Estate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepository.CreateCategoryAsync(createCategoryDto);
            return Ok("kategori başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori güncellendi başarılııı.");

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(int categoryID)
        {
            _categoryRepository.DeleteCategoryAsync(categoryID);
            return Ok("kayıt silindi.");
        }

        [HttpGet]
        [Route("{categoryID}")]
        public async Task<IActionResult> GetCategory(int categoryID)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryID);
            return Ok(category);
        }


    }


}