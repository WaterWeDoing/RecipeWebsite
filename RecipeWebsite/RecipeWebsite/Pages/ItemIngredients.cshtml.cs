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


        public void OnGet(int Id)
        {
            Recipe = _recipeRepo.GetRecipe(Id);



        }
    }
}
