using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Seeders
{
    public class CategorySeeders
    {
        public static void Seed(ModelBuilder modelBuilder){
            modelBuilder.Entity<ProductCategory>().HasData(
                // category
                new ProductCategory { Id = 1, Name = "desktp", Description ="powerful desktop computers designed for both home and professional use. From basic models to advanced workstations for intensive tasks, find the right fit for your needs."},

                new ProductCategory {Id = 2, Name = "mobile", Description = "discover the latest smartphones with cutting-edge technology. From flagship models to budget-friendly options, we offer devices for every lifestyle"},

                new ProductCategory {Id = 3, Name = "accesories", Description = "essential tech accessories, including chargers, cases, keyboards, headphones, and more to enhance your experience"},

                new ProductCategory {Id = 4, Name = "sofware", Description = "software solutions for all your needs, from operating systems and office suites to design, development, and digital security tools."}
            );
        }
    }
}