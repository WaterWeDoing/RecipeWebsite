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


        public IActionResult OnPost(List<string> ingredients, int recipeItemId, string item) 
        {
            // We need to get the existing item from the DB here

            // We update it here
            RecipeItem recipeItem = new RecipeItem()
            {
                RecipeItemId = recipeItemId,
                Ingredients = ingredients,
                Item = item,
            };

            // We need to save the item to the DB here.

            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        public void OnGet(int Id)
        {
            Recipe = _recipeRepo.GetRecipe(Id);

        }
    }
}
