using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.Products
{
    [ApiController]
    [Route("api/v1/products")]
    [Tags("products")]
    public class ProductDeleteController : ProductController
    {
        public ProductDeleteController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (int id){
            await _productRepository.Delete(id);
            return NoContent();
        }
    }
}