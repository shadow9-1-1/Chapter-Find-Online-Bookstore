using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chapter_Find_Online_Bookstore.Services
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            var Admin = new IdentityRole("admin");
            Admin.NormalizedName = "admin";

            var Customers = new IdentityRole("customers");
            Customers.NormalizedName = "customers";

            Builder.Entity<IdentityRole>().HasData(Admin, Customers);

        }
    }
}
