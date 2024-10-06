using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.ProductCategories
{
    [ApiController]
    [Route("api/v1/categories")]
    [Tags("category")]
    public class ProductCategoryGetController : ProductCategoryController
    {
        public ProductCategoryGetController(IProductCategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpGet]
         public async Task<ActionResult<IEnumerable<ProductCategory>>> Get(){
            var product1 = await _categoryRepository.Get();
            return Ok(product1);
        }
    }
}