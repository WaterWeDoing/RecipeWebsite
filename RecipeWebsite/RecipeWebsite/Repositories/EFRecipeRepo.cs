using RecipeWebsite.Data;
using RecipeWebsite.Models;
using RecipeWebsite.Repositories.Interfaces;

namespace RecipeWebsite.Repositories
{
    public class EFRecipeRepo : IRecipeRepo
    {
        private readonly RecipeDbContext _context;

        public EFRecipeRepo(RecipeDbContext context)
        {
            _context = context;
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public List<Recipe> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        public Recipe GetRecipe(int id)
        {
            var r = _context.Recipes.FirstOrDefault(x => x.Id == id);
            return r;
        }
    }
}
