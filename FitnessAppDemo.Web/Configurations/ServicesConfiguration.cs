using FitnessAppDemo.Logic.Models;
using FitnessAppDemo.Logic.Services;
using FitnessAppDemo.Logic.Validators;
using FluentValidation;

namespace FitnessAppDemo.Web.Configurations
{
    public static class ServicesConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IValidator<ProductCategoryDto>, ProductCategoryValidator>();
            builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
        }
    }
}
