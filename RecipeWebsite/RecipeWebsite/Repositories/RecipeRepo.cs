using RecipeWebsite.Models;
using RecipeWebsite.Repositories.Interfaces;

namespace RecipeWebsite.Repositories
{
    public class RecipeRepo : IRecipeRepo
    {
        private static List<Recipe> _recipes = new List<Recipe>();
        private static int _currentId = 1;

        public void AddRecipe(Recipe recipe)
        {
            recipe.RecipeId = _currentId++;
            _recipes.Add(recipe);
        }

        public Recipe GetRecipe(int id)
        {
            foreach(var recipe in _recipes)
            {
                if (recipe.RecipeId == id)
                {
                    return recipe;
                }
            }
            return null;
        }

        public List<Recipe> GetAllRecipes()
        {
            return _recipes;
        }
    }
}
