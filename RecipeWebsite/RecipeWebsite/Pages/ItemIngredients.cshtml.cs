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

        private readonly IRecipeItemRepo _recipeItemRepo;

        public Recipe Recipe { get; set; }

        public ItemIngredientsModel(IRecipeRepo recipeRepo, IRecipeItemRepo recipeItemRepo)
        {
            _recipeRepo = recipeRepo;
            _recipeItemRepo = recipeItemRepo;
        }


        public IActionResult OnPost(List<RecipeItem> recipeItems) 
        {
            foreach (RecipeItem item in recipeItems)
            {
                RecipeItem? itemDb = _recipeItemRepo.GetRecipeItem(item.RecipeItemId);
                if (itemDb == null)
                {
                    return new StatusCodeResult(StatusCodes.Status404NotFound);
                }                

                itemDb.Item = item.Item;
                itemDb.Ingredients = item.Ingredients;
                _recipeItemRepo.SaveRecipeItem(itemDb);
            }

            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        public void OnGet(int Id)
        {
            Recipe = _recipeRepo.GetRecipe(Id);

        }

        
    }
}
