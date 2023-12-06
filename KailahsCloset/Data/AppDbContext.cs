using KailahsCloset.Models;
using Microsoft.EntityFrameworkCore;

namespace KailahsCloset.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Jacket", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Jeans", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Blouse", DisplayOrder = 3 }
                );
        }
    }
}
