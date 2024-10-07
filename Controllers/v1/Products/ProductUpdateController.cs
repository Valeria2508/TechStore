using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechStore.DTO;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.Products
{
    [ApiController]
    [Route("api/v1/products")]
    [Tags("products")]
    [Authorize]
    public class ProductUpdateController : ProductController
    {
        public ProductUpdateController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Update([FromHeader]int id, [FromBody] ProductDTO product){
            await _productRepository.Update(id, product);
            return Ok();
        }
    }
}