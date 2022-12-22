using FitnessAppDemo.Logic.Models;
using Swashbuckle.AspNetCore.Filters;

namespace FitnessAppDemo.Web.SwaggerExamples
{
    public class ProductCategoryCreateExample : IExamplesProvider<ProductCategoryDto> // install Swashbuckle.AspNetCore.Filters nuget
    {
        public ProductCategoryDto GetExamples()
        {
            return new ProductCategoryDto()
            {
                Title = "Product category"
            };
        }
    }

    public class ProductCategoryUpdateExample : IExamplesProvider<ProductCategoryDto> // install Swashbuckle.AspNetCore.Filters nuget
    {
        public ProductCategoryDto GetExamples()
        {
            return new ProductCategoryDto()
            {
                Id = 1,
                Title = "Product category"
            };
        }
    }
}
