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
    public class ProductController : ControllerBase
    {
        protected readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}