using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Models;

namespace RecipeWebsite.Data
{
    public class IdentityDbContext : IdentityDbContext<RecipeUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RecipeItem>()
                .Ignore(x => x.Ingredients);

            base.OnModelCreating(builder);
        }
    }
}