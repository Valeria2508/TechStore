using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.DTO.ProductCategories;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Services
{
    public class ProductCategoryService : IProductCategoryRepository
    {
        protected readonly ApplicationDbContext _context;

        public ProductCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(ProductCategoryDTO category)
        {
            var category1 = new ProductCategory{
                Name = category.Name,
                Description = category.Description,
            };
            _context.ProductCategories.Add(category1);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category != null)
            {
                _context.ProductCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductCategoryDTO>> Get()
        {
            var category = await _context.ProductCategories.Select(category => new ProductCategoryDTO{
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            }).ToListAsync();
            return category;
        }

        public async Task Update(int id, ProductCategoryDTO category)
        {
            var category1 = await _context.ProductCategories.FindAsync(id);
            if (category1 != null)
            {
                category1.Name = category.Name;
                category1.Description = category.Description;

                _context .Entry(category1).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}