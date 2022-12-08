using FamiliarBudgetApi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<User> User { get; set; }
        public DbSet<Family> Family { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
