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


        public IActionResult OnPost(List<RecipeItemsTarget> recipeItems) 
        {
            // We need to loop over each item
            // pull it from the database based on the recipeItemId
            // update it
            // save it back to to db


            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        public void OnGet(int Id)
        {
            Recipe = _recipeRepo.GetRecipe(Id);

        }

        public class RecipeItemsTarget
        {
            public int RecipeItemId { get; set; }
            public List<string> Ingredients { get; set; }
            public string Item { get; set; }
        }
    }
}
