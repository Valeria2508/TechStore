using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.DTO;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Services
{
    public class ProductSerice : IProductRepository
    {
        protected readonly ApplicationDbContext _context;

        public ProductSerice(ApplicationDbContext context) 
        {
            _context = context;
        }


        //logica para agg un producto
        public async Task Add(ProductDTO product)
        {
            var product1 = new Product{
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                ProductCategoryId = product.ProductCategoryId
            };
            _context.Products.Add(product1);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product1 = await _context.Products.FindAsync(id);
            if (product1 != null)
            {
                _context.Products.Remove(product1);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDTO>> Get() //get es obtener
        {
            var product1 = await _context.Products.Include(p => p.ProductCategories).Select(product1 => new ProductDTO{
                Id = product1.Id,
                Name = product1.Name,
                Description = product1.Description,
                Price = product1.Price,
                Quantity = product1.Quantity,
                ProductCategoryId = product1.ProductCategoryId,
                ProductCategoryName = product1.ProductCategories.Name
            }).ToListAsync();
            return product1;
        }

        public async Task Update(int id,ProductDTO product)
        {
            var product1 = await _context.Products.FindAsync(id);
            if (product1 != null)
            {
                product1.Name = product.Name;
                product1.Description = product.Description;
                product1.Price = product.Price;
                product1.Quantity = product.Quantity;
                product1.ProductCategoryId = product.ProductCategoryId;

                _context .Entry(product1).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}