using Estate.Api.Models.DapperContext.Dtos.CategoryDtos;

namespace Estate.Api.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        void UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

        void DeleteCategoryAsync(int categoryID);

        Task<ResultCategoryDto> GetCategoryByIdAsync(int categoryID);
    }
}