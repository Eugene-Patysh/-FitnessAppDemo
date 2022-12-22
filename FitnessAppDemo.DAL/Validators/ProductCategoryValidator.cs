using FitnessAppDemo.Logic.Models;
using FluentValidation;

namespace FitnessAppDemo.Logic.Validators
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategoryDto>
    {
        public ProductCategoryValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(o => o).NotNull().WithMessage("Product category can't be null.");

            RuleSet("AddProductCategory", () =>
            {
                RuleFor(o => o.Id).Null().WithMessage("Product category Id must be null.");
            });

            RuleSet("UpdateProductCategory", () =>
            {
                RuleFor(o => o.Id).NotNull().WithMessage("Product category Id can't be null.");
            });

            RuleFor(o => o.Title)
                .Must(t => !string.IsNullOrEmpty(t)).WithMessage("Product category title can't be null.")
                .MaximumLength(30).WithMessage("Length of product category title can't be more than 30 symbols.");
        }
    }
}
