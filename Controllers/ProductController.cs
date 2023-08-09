
using Estate.Api.Repository.ProductRepository;
using Microsoft.AspNetCore.Mvc;

namespace Estate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var products = await _productRepository.GetAllProductsAsync();

            return Ok(products);
        }
    }
}