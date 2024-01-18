using Microsoft.EntityFrameworkCore;
using KailahsCloset.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KailahsCloset.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Jacket", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Jeans", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "T-Shirt", DisplayOrder = 3 },
                new Category { CategoryId = 4, Name = "Pants", DisplayOrder = 4 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { 
                    ProductId = 1, 
                    Name = "Nike Zip-Up Hoodie",
                    Brand = "Nike",
                    Size = "Large",
                    Description = "Black Nike zip-Up hoodie",
                    Price = 30.00,
                    CategoryId = 1,
                    ImageURL = ""
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Levi's Slim-Fit Jeans",
                    Brand = "Levi's",
                    Size = "32x32",
                    Description = "Dark wash slim-fit jeans for all occasions",
                    Price = 35.00,
                    CategoryId = 2,
                    ImageURL = ""
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Uniqulo Grey Tee",
                    Brand = "Uniqulo",
                    Size = "Large",
                    Description = "60% cotton / 40% polyester slim-fit grey tee.",
                    Price = 12.00,
                    CategoryId = 3,
                    ImageURL = ""
                },
                new Product
                {
                    ProductId = 4,
                    Name = "ASColour Navy Blue Tee",
                    Brand = "ASColour",
                    Size = "Large",
                    Description = "65% cotton / 35% polyester slim-fit navy blue tee.",
                    Price = 12.00,
                    CategoryId = 3,
                    ImageURL = ""
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Flag & Anthem Oakland Slim Chinos",
                    Brand = "Flag & Anthem",
                    Size = "33x32",
                    Description = "60% cotton / 40% polyester dark grey chino pants.",
                    Price = 38.00,
                    CategoryId = 4,
                    ImageURL = ""
                });
        }
    }
}
