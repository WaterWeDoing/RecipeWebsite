using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeWebsite.Models;
using RecipeWebsite.Repositories;
using RecipeWebsite.Repositories.Interfaces;

namespace RecipeWebsite.Pages
{
    public class DisplayRecipeModel : PageModel
    {
        public Recipe Recipe { get; set; }

        private readonly IRecipeRepo _recipeRepo;

        public DisplayRecipeModel(IRecipeRepo recipe)
        {
            _recipeRepo = recipe;
        }

        public void OnGet(int id)
        {
            Recipe = _recipeRepo.GetRecipe(id);
        }
    }
}
