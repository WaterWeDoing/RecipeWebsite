using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeWebsite.Data;
using RecipeWebsite.Models;
using RecipeWebsite.Repositories.Interfaces;

namespace RecipeWebsite.Pages
{
    public class ItemIngredientsModel : PageModel
    {
        private readonly IRecipeRepo _recipeRepo;
        public Recipe Recipe { get; set; }


        public ItemIngredientsModel(IRecipeRepo recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }


        public void OnPost(List<string> ingredients, int recipeId, string item) 
        {
            var test = ingredients;
            var testid = recipeId;

            RecipeItem recipeItem = new RecipeItem()
            {
                RecipeId = recipeId,
                Ingredients = ingredients,
                Item = item,
            };

        }

        public void OnGet(int Id)
        {
            Recipe = _recipeRepo.GetRecipe(Id);

        }
    }
}
