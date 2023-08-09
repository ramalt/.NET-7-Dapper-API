namespace Estate.Api.Models.DapperContext.Dtos.CategoryDtos
{
    public class DeleteCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}