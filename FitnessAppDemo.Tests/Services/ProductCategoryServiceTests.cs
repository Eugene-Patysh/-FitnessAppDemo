using FitnessAppDemo.Data;
using FitnessAppDemo.Data.Models;
using FitnessAppDemo.Logic.Models;
using FitnessAppDemo.Logic.Services;
using FitnessAppDemo.Logic.Validators;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Entity.Infrastructure;
using Xunit;

namespace FitnessAppDemo.Tests.Services
{
    public class ProductCategoryServiceTests
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly ProductCategoryValidator _validator;

        public ProductCategoryServiceTests()
        {
            //var dbContext = CreateDbContext();
            //_validator = new ProductCategoryValidator();
            //_productCategoryService = new ProductCategoryService(dbContext, _validator);
        }

        private ProductContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
            var dbContext = new ProductContext(options);
            return dbContext;
        }

        [Fact]
        public async Task CreateAsync_HappyCase()
        {
            var productCategory = new ProductCategoryDto() { Title = "Meat" };
            
            await _productCategoryService.CreateAsync(productCategory);
            var categories = await _productCategoryService.GetAllAsync();

            var createdCategory = categories.FirstOrDefault(c => c.Title == "Meat");
            
            Assert.NotNull(createdCategory);
            Assert.NotNull(createdCategory?.Id);
        }

        //[Fact]
        //public async Task GetAllAsync_HappyCase()
        //{
        //    var categories = await _productCategoryService.GetAllAsync();

        //    Assert.Equal(3, categories.Length);
        //    Assert.Equal("Meat", categories[0].Title);
        //    Assert.Equal("Vegetables", categories[1].Title);
        //    Assert.Equal("Fruit", categories[2].Title);
        //}
    }
}
