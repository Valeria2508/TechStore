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
    public class ProductPostController : ProductController
    {
        public ProductPostController(IProductRepository productRepository) : base(productRepository)
        {
        }

       [HttpPost] 
        public async Task<ActionResult<Product>> Post([FromBody] ProductDTO product)
        {
            await _productRepository.Add(product);
            return Ok();
        }
    }
}