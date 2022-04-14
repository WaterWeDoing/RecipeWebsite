using Microsoft.EntityFrameworkCore;
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

        public void UpdateRecipe(Recipe recipe)
        { 
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        
        }

        public void AddRecipe(Recipe recipe)
        {
            recipe.DateAdded = DateTime.Now;
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public List<Recipe> GetAllRecipes()
        {

            return _context.Recipes.Include(r => r.RecipeItems).ToList();
        }

        public Recipe? GetRecipe(int id)
        {
            var r = _context.Recipes
                .Include(r => r.RecipeItems)
                .Include(r => r.Submitter)
                .Include(r => r.Comments)
                .Include(r => r.MainIngredients)
                .SingleOrDefault(x => x.RecipeId == id);

            return r;
        }
    }
}
