using FitnessAppDemo.Logic;
using FitnessAppDemo.Logic.Models;
using FitnessAppDemo.Logic.Services;
using FitnessAppDemo.Web.SwaggerExamples;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Filters;

namespace FitnessAppDemo.Web.Controllers
{
    [ApiController]
    [Route("api/v1.0/productCategory")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IStringLocalizer<ProductCategoryController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        public ProductCategoryController(IProductCategoryService productCategoryService,
                                        IStringLocalizer<ProductCategoryController> localizer,
                                        IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _productCategoryService = productCategoryService;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet("{productCategoryId}")]
        public async Task<ActionResult<ProductCategoryDto>> GetByIdAsync(int? productCategoryId)
        {
            //throw new ValidationException(String.Format(_sharedLocalizer["BadRequest"]));

            if (productCategoryId == null)
                BadRequest();

            var productCategory = await _productCategoryService.GetByIdAsync(productCategoryId);

            return productCategory == null ? NotFound() : Ok(productCategory);
        }

        /// <summary>
        /// Creates new product category
        /// </summary>
        /// <remarks>Title must be alphabetic characters with a maximum length of 30 characters</remarks>
        /// <param name="productCategory"></param>
        /// <returns>Returns success/fail status</returns>
        /// <response code="200">Successful product category creation</response>
        /// <response code="400">Some fields have incorrect values</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(ProductCategoryDto), typeof(ProductCategoryCreateExample))]
        public async Task CreateAsync([FromBody] ProductCategoryDto productCategory)
        {

            if (!ModelState.IsValid)
                BadRequest(ModelState);
            //throw new ValidationException(_sharedLocalizer["BadRequest"]);
            await _productCategoryService.CreateAsync(productCategory);
        }

        /// <summary>
        /// Updates existing product category
        /// </summary>
        /// <remarks>Title must be alphabetic characters with a maximum length of 30 characters</remarks>
        /// <param name="productCategory"></param>
        /// <returns>Returns success/fail status</returns>
        /// <response code="200">Successful product category updation</response>
        /// <response code="400">Some fields have incorrect values</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(ProductCategoryDto), typeof(ProductCategoryUpdateExample))]
        public async Task UpdateAsync([FromBody] ProductCategoryDto productCategory)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            await _productCategoryService.UpdateAsync(productCategory);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromBody] int? productCategoryId)
        {
            if (productCategoryId == null)
                BadRequest();

            await _productCategoryService.DeleteAsync(productCategoryId);

            return Ok();
        }
    }
}
