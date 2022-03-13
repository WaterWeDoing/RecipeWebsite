using Microsoft.EntityFrameworkCore;

namespace RecipeWebsite.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
        : base(options)
        {
            


        }

    }
}
