using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Seeders
{
    public class ProductSeederes
    {
        public static void Seed(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().HasData(
                // Desktop category
                new Product { Id = 1, Name = "gaming desktop", Description = "powerful desktop for gaming with the latest hardware.", Price = 1500.00M, Quantity = 30, ProductCategoryId = 1 },
                new Product { Id = 2, Name = "workstation desktop", Description = "desktop optimized for high-performance tasks like video editing.", Price = 1800.00M, Quantity = 15, ProductCategoryId = 1 },
                new Product { Id = 3, Name = "compact desktop", Description = "compact desktop for home or office use.", Price = 600.00M, Quantity = 60, ProductCategoryId = 1 },
                new Product { Id = 4, Name = "all-in-one desktop", Description = "all-in-one desktop with a sleek design, perfect for space-saving.", Price = 1200.00M, Quantity = 40, ProductCategoryId = 1 },
                new Product { Id = 5, Name = "budget desktop", Description = "affordable desktop ideal for basic tasks and everyday use.", Price = 400.00M, Quantity = 100, ProductCategoryId = 1 },

                // Mobile category
                new Product { Id = 6, Name = "flagship smartphone", Description = "high-end smartphone with the latest technology and camera.", Price = 1000.00M, Quantity = 50, ProductCategoryId = 2 },
                new Product { Id = 7, Name = "budget smartphone", Description = "affordable smartphone with all the essential features.", Price = 200.00M, Quantity = 150, ProductCategoryId = 2 },
                new Product { Id = 8, Name = "mid-range smartphone", Description = "smartphone offering a great balance of performance and price.", Price = 500.00M, Quantity = 100, ProductCategoryId = 2 },
                new Product { Id = 9, Name = "gaming smartphone", Description = "smartphone built for mobile gaming with enhanced graphics.", Price = 800.00M, Quantity = 40, ProductCategoryId = 2 },
                new Product { Id = 10, Name = "rugged smartphone", Description = "durable smartphone designed for tough environments.", Price = 600.00M, Quantity = 70, ProductCategoryId = 2 },
                // Accessories category
                new Product { Id = 11, Name = "wireless mouse", Description = "ergonomic wireless mouse with long battery life.", Price = 25.00M, Quantity = 200, ProductCategoryId = 3 },
                new Product { Id = 12, Name = "mechanical keyboard", Description = "high-quality mechanical keyboard for precision typing.", Price = 100.00M, Quantity = 150, ProductCategoryId = 3 },
                new Product { Id = 13, Name = "smartwatch", Description = "smartwatch with fitness tracking and notification features.", Price = 150.00M, Quantity = 80, ProductCategoryId = 3 },
                new Product { Id = 14, Name = "wireless earbuds", Description = "compact wireless earbuds with noise-cancelling technology.", Price = 75.00M, Quantity = 250, ProductCategoryId = 3 },
                new Product { Id = 15, Name = "usb-c hub", Description = "multi-port usb-c hub for enhanced connectivity.", Price = 50.00M, Quantity = 180, ProductCategoryId = 3 },

                // Software category
                new Product { Id = 16, Name = "antivirus software", Description = "comprehensive antivirus software for real-time protection.", Price = 40.00M, Quantity = 300, ProductCategoryId = 4 },
                new Product { Id = 17, Name = "office suite", Description = "complete office suite including word processing and spreadsheets.", Price = 120.00M, Quantity = 150, ProductCategoryId = 4 },
                new Product { Id = 18, Name = "photo editing software", Description = "professional-grade photo editing software with advanced tools.", Price = 200.00M, Quantity = 80, ProductCategoryId = 4 },
                new Product { Id = 19, Name = "accounting software", Description = "easy-to-use accounting software for small businesses.", Price = 100.00M, Quantity = 100, ProductCategoryId = 4 },
                new Product { Id = 20, Name = "project management software", Description = "powerful project management tool for teams and individuals.", Price = 150.00M, Quantity = 90, ProductCategoryId = 4 }
            );
        }
    }
}