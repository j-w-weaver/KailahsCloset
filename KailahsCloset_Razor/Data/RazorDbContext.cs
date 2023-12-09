using KailahsCloset_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace KailahsCloset_Razor.Data
{
    public class RazorDbContext : DbContext 
    {
        public RazorDbContext(DbContextOptions<RazorDbContext> options) : base(options)
        {

        }       
        public DbSet<Types> Types { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Types>().HasData(
                new Types { Id = 1, Name = "Jacket", Description = "dg" },
                new Types { Id = 2, Name = "Jeans", Description = "agaeg" },
                new Types { Id = 3, Name = "Blouse", Description = "avegbt" }
                );
        }
    }
}
