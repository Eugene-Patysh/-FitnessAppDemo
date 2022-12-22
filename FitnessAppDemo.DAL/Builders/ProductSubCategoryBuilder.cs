using FitnessAppDemo.Data.Models;
using FitnessAppDemo.Logic.Models;

namespace FitnessAppDemo.Logic.Builders
{
    public static class ProductSubCategoryBuilder
    {
        public static ProductSubCategoryDto Build(ProductSubCategoryDb db)
        {
            return db != null
                ? new ProductSubCategoryDto()
                {
                    Id = db.Id,
                    Title = db.Title,
                    ProductCategoryId = db.Id,
                    ProductCategory = ProductCategoryBuilder.Build(db.ProductCategory),
                    //Products = ProductBuilder.Build(db.Products),
                    Created = db.Created,
                    Updated = db.Updated
                }
                : null;
        }

        public static ICollection<ProductSubCategoryDto> Build(ICollection<ProductSubCategoryDb> col)
        {
            return col?.Select(a => Build(a))?.ToArray();
        }

        public static ProductSubCategoryDb Build(ProductSubCategoryDto db)
        {
            return db != null
                ? new ProductSubCategoryDb()
                {
                    Id = db.Id,
                    Title = db.Title,
                    ProductCategoryId = db.Id,
                    ProductCategory = ProductCategoryBuilder.Build(db.ProductCategory),
                    //Products = ProductBuilder.Build(db.Products),
                    Created = db.Created,
                    Updated = db.Updated
                }
                : null;
        }

        public static ICollection<ProductSubCategoryDb> Build(ICollection<ProductSubCategoryDto> col)
        {
            return col?.Select(c => Build(c))?.ToArray();
        }
    }
}
