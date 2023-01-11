using FitnessAppDemo.Data;
using FitnessAppDemo.Logic.ApiModels;
using FitnessAppDemo.Logic.Builders;
using FitnessAppDemo.Logic.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace FitnessAppDemo.Logic.Services
{
    public class ProductCategoryService : BaseService, IProductCategoryService
    {
        private readonly IValidator<ProductCategoryDto> _validator;

        public ProductCategoryService(ProductContext context, IValidator<ProductCategoryDto> validator) : base(context)
        {
            _validator = validator;
        }

        public async Task<PaginationResponse<ProductCategoryDto>> GetPagination(PaginationRequest request)
        {
            var query = _context.ProductCategories.AsQueryable();

            if (!string.IsNullOrEmpty(request.Query))
            {
                query = query.Where(c => c.Title.Contains(request.Query, StringComparison.OrdinalIgnoreCase));
            }
            
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                switch (request.SortBy)
                {
                    case "title": query = request.Asc ? query.OrderBy(c => c.Title) : query.OrderByDescending(c => c.Title); break;
                }
            }
            var categoryDbs = await query.ToArrayAsync().ConfigureAwait(false);

            var total = categoryDbs.Length;
            var categoryDtos = ProductCategoryBuilder.Build(categoryDbs.Skip(request.Skip ?? 0).Take(request.Take ?? 10))?.ToArray();

            return new PaginationResponse<ProductCategoryDto>
            {
                Total = total,
                Values = categoryDtos
            };
        }

        public async Task<ProductCategoryDto[]> GetAllAsync()
        {
            var categoryDbs = await _context.ProductCategories.ToArrayAsync().ConfigureAwait(false);

            return ProductCategoryBuilder.Build(categoryDbs)?.ToArray();
        }

        public async Task<ProductCategoryDto> GetByIdAsync(int? productCategoryDtoId)
        {
            if (productCategoryDtoId == null)
            {
                throw new ValidationException("Product Category Id can't be null.");
            }

            var categoryDb = await _context.ProductCategories.SingleOrDefaultAsync(_ => _.Id == productCategoryDtoId).ConfigureAwait(false);

            return ProductCategoryBuilder.Build(categoryDb);
        }

        public async Task CreateAsync(ProductCategoryDto productCategoryDto)
        {
            var validationResult = _validator.Validate(productCategoryDto, v => v.IncludeRuleSets("AddProductCategory"));
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.ToString());

            productCategoryDto.Created = DateTime.UtcNow;
            productCategoryDto.Updated = DateTime.UtcNow;

            await _context.ProductCategories.AddAsync(ProductCategoryBuilder.Build(productCategoryDto)).ConfigureAwait(false);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Product category has not been created. {ex.Message}.");
            }
        }

        public async Task UpdateAsync(ProductCategoryDto productCategoryDto)
        {
            var validationResult = _validator.Validate(productCategoryDto, v => v.IncludeRuleSets("UpdateProductCategory"));
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.ToString());

            var categoryDb = await _context.ProductCategories.SingleOrDefaultAsync(_ => _.Id == productCategoryDto.Id).ConfigureAwait(false);

            if (categoryDb != null)
            {
                categoryDb.Title = productCategoryDto.Title;
                categoryDb.Updated = DateTime.UtcNow;

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Product category has not been updated. {ex.Message}.");
                }
            }
            else
            {
                throw new ValidationException($"There is not exist object, that you trying to update.");
            }
        }

        public async Task DeleteAsync(int? productCategoryDtoId)
        {
            if (productCategoryDtoId == null)
            {
                throw new ValidationException("Invalid product category Id.");
            }

            var categoryDb = await _context.ProductCategories.SingleOrDefaultAsync(_ => _.Id == productCategoryDtoId).ConfigureAwait(false);

            if (categoryDb != null)
            {
                _context.ProductCategories.Remove(categoryDb);

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Product category has not been deleted. {ex.Message}.");
                }
            }
            else
            {
                throw new ValidationException($"There is not exist object, that you trying to delete.");
            }
        }
    }
}
