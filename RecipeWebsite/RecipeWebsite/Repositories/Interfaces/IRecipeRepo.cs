using RecipeWebsite.Models;

namespace RecipeWebsite.Repositories.Interfaces;

public interface IRecipeRepo
{
    void AddRecipe(Recipe recipe);
    Recipe? GetRecipe(int id);
    List<Recipe> GetAllRecipes();
}