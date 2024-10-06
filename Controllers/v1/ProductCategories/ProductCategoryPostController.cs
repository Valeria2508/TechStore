using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.DTO.ProductCategories;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.ProductCategories
{
    [ApiController]
    [Route("api/v1/categories")]
    [Tags("category")]
    public class ProductCategoryPostController : ProductCategoryController
    {
        public ProductCategoryPostController(IProductCategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategory>> Post(ProductCategoryDTO productCategory){
            
            await _categoryRepository.Add(productCategory);
            return Ok();
        }
    }
}