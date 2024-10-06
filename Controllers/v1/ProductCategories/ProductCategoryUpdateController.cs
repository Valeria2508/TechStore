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
    public class ProductCategoryUpdateController : ProductCategoryController
    {
        public ProductCategoryUpdateController(IProductCategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpPut]

        public async Task<ActionResult<ProductCategory>> Update([FromHeader] int id, [FromBody] ProductCategoryDTO productCategory){
            await _categoryRepository.Update(id, productCategory);
            return Ok();

        }
    }
}