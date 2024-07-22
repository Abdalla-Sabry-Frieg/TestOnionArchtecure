using LearnCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnCore.Data
{
    public class ApplicationDbContext :IdentityDbContext<IdentityUser>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                    new Category() { Id = 1, Name = "Select Category" },
                    new Category() { Id = 2, Name = "Computer" },
                    new Category() { Id = 3, Name = "Laptops" },
                    new Category() { Id = 4, Name = "Mobiles" });

            // To Add User Role to control the data which user can access to it then add migration

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName="admin", // the same name but small letter
                ConcurrencyStamp = Guid.NewGuid().ToString() 
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "user",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });



        }


    }
}
