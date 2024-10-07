using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.Products
{
    [ApiController]
    [Route("api/v1/products")]
    [Tags("products")]
    public class ProductGetController : ProductController
    {
        public ProductGetController(IProductRepository productRepository) : base(productRepository)
        {
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Product>>> Get(){
            var product1 = await _productRepository.Get();
            return Ok(product1);
        }
    }
}