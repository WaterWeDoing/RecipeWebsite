using RecipeWebsite.Models;

namespace RecipeWebsite.Repositories.Interfaces;

public interface IRecipeRepo
{
    void AddRecipe(Recipe recipe);
    Recipe? GetRecipe(int id);
    void UpdateRecipe(Recipe recipe);
    List<Recipe> GetAllRecipes();
}