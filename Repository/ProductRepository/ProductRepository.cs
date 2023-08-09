using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Estate.Api.Models.DapperContext;
using Estate.Api.Models.DapperContext.Dtos.ProductDtos;

namespace Estate.Api.Repository.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

    //ℹ️ All products with category name instead of category id😎

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        string query = "SELECT ProductID,Title,Price,City,Address,Description,CoverImage,CategoryName FROM Product INNER JOIN Category on Product.ProductCategory = Category.CategoryID";

        using var conn = _context.CreateConnection();

        var values = await conn.QueryAsync<ResultProductDto>(query);
        return values.ToList();
    }
}
