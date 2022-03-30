using RecipeWebsite.Models;

namespace RecipeWebsite.Repositories.Interfaces
{
    public interface IRecipeItemRepo
    {
        RecipeItem? GetRecipeItem(int id);
        void SaveRecipeItem(RecipeItem recipeItem);
    }
}