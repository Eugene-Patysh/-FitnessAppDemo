using FitnessAppDemo.Logic.Models;

namespace FitnessAppDemo.Logic.Services
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryDto[]> GetAllAsync();
        Task<ProductCategoryDto> GetByIdAsync(int? productCategoryDtoId);
        Task CreateAsync(ProductCategoryDto productCategoryDto);
        Task UpdateAsync(ProductCategoryDto productCategoryDto);
        Task DeleteAsync(int? productCategoryDtoId);
    }
}
