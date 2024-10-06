using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.DTO.ProductCategories;

namespace TechStore.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategoryDTO>> Get();
        Task Add(ProductCategoryDTO category);
        Task Delete(int id);
        Task Update(int id, ProductCategoryDTO category);
    }
}