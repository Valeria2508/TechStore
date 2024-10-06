using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.DTO;
using TechStore.Models;

namespace TechStore.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> Get();
        Task Add(ProductDTO product);
        Task Delete(int id);
        Task Update(int id,ProductDTO product);
    }
}