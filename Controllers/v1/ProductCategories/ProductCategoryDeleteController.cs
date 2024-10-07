using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.ProductCategories
{
    [ApiController]
    [Route("api/v1/categories")]
    [Tags("category")]
    [Authorize]
    public class ProductCategoryDeleteController : ProductCategoryController
    {
        public ProductCategoryDeleteController(IProductCategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id){
            await _categoryRepository.Delete(id);
            return NoContent();
        }
    }
}