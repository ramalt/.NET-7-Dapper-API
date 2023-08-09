using Estate.Api.Models.DapperContext.Dtos.ProductDtos;

namespace Estate.Api.Repository.ProductRepository;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
}
