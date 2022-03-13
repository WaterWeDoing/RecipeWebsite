using RecipeWebsite.Models;

namespace RecipeWebsite.Services;

public interface IRecipeRepo
{
    void AddRecipe(Recipe recipe);
    Recipe GetRecipe(int id);
    List<Recipe> GetAllRecipes();
}