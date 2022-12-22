using FitnessAppDemo.Data.Models;
using FitnessAppDemo.Logic.Models;

namespace FitnessAppDemo.Logic.Builders
{
    public static class ProductCategoryBuilder
    {
        public static ProductCategoryDto Build(ProductCategoryDb db)
        {
            return db != null
                ? new ProductCategoryDto()
                {
                    Id = db.Id,
                    Title = db.Title,
                    ProductSubCategories = ProductSubCategoryBuilder.Build(db.ProductSubCategories),
                    Created = db.Created,
                    Updated = db.Updated
                }
                : null;
        }

        public static IEnumerable<ProductCategoryDto> Build(IEnumerable<ProductCategoryDb> dbs)
        {
            return dbs?.Select(db => Build(db));
        }

        public static ProductCategoryDb Build(ProductCategoryDto db)
        {
            return db != null
                ? new ProductCategoryDb()
                {
                    Id = db.Id,
                    Title = db.Title,
                    ProductSubCategories = ProductSubCategoryBuilder.Build(db.ProductSubCategories),
                    Created = db.Created,
                    Updated = db.Updated
                }
                : null;
        }
        public static IEnumerable<ProductCategoryDb> Build(IEnumerable<ProductCategoryDto> dbs)
        {
            return dbs?.Select(db => Build(db));
        }
    }
}
