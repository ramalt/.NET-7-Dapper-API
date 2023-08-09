using Dapper;
using Estate.Api.Models.DapperContext;
using Estate.Api.Models.DapperContext.Dtos.CategoryDtos;

namespace Estate.Api.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "INSERT INTO Category (CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";
            var parameters = new DynamicParameters();

            //Add parameters to Dapper dynamic parameter list👀
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);

            using (var conn = _context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategoryAsync(int categoryID)
        {
            string query = "DELETE FROM Category WHERE CategoryID = @ctgID ";

            var parameters = new DynamicParameters();
            parameters.Add("@ctgID", categoryID);

            using (var conn = _context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);

            }

        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "SELECT * FROM Category";

            using var conn = _context.CreateConnection();
            //this is Dapper baby😎  😏🕶️🤏
            var values = await conn.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();

        }

        public async Task<ResultCategoryDto> GetCategoryByIdAsync(int categoryID)
        {
            string query = "SELECT * FROM Category WHERE CategoryID = @ctgID";

            var parameters = new DynamicParameters();
            parameters.Add("@ctgID", categoryID);

            using (var conn = _context.CreateConnection())
            {
                var category = await conn.QueryFirstOrDefaultAsync<ResultCategoryDto>(query, parameters);
                return category;
            }
        }

        public async void UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "UPDATE Category SET CategoryName = @ctgName, CategoryStatus = @ctgStatus WHERE CategoryID = @ctgID ";
            var parameters = new DynamicParameters();

            parameters.Add("@ctgID", updateCategoryDto.CategoryID);
            parameters.Add("@ctgName", updateCategoryDto.CategoryName);
            parameters.Add("@ctgStatus", updateCategoryDto.CategoryStatus);

            using (var conn = _context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);

            }


        }
    }
}