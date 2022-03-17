using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecipeWebsite.Models;
using System.Text.Json;

namespace RecipeWebsite.Data
{
    public class RecipeDbContext : IdentityDbContext<RecipeUser>
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options) {}

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RecipeItem>()
                            .Property(e => e.Ingredients)
                            .HasConversion(
                                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
                                new ValueComparer<ICollection<string>>(
                                    (c1, c2) => c1.SequenceEqual(c2),
                                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                                    c => (ICollection<string>)c.ToList()));

            base.OnModelCreating(builder);
        }
    }
}