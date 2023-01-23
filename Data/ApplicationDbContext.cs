using ManageLibraryItemsAndEmployees.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace ManageLibraryItemsAndEmployees.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var administratorRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            };

            builder.Entity<IdentityRole>()
                .HasData(administratorRole);

            //Create categories with unique names
            builder.Entity<Category>()
                .HasIndex(p => new { p.CategoryName })
                .IsUnique(true);
        }
    }
}