using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.ProductCategories
{
    [ApiController]
    [Route("api/v1/categories")]
    public class ProductCategoryController : ControllerBase
    {
        protected readonly IProductCategoryRepository _categoryRepository;

        public ProductCategoryController(IProductCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}