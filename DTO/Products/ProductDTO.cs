using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTO
{
    public class ProductDTO
    {
        public int Id { get; set;}
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public required int ProductCategoryId { get; set; }
        public required string ProductCategoryName { get; set; }
    }
}