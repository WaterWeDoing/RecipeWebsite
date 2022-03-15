using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeWebsite.Models;
using RecipeWebsite.Repositories.Interfaces;

namespace RecipeWebsite.Pages
{
    public class AddRecipeModel : PageModel
    {
        [BindProperty]
        public Recipe Recipe { get; set; }

		private readonly IRecipeRepo _repo;

        [BindProperty]
        [Display(Name = "Main Ingredient")]
        public string MainIngredient { get; set; }

        public AddRecipeModel(IRecipeRepo repo)
        {
            _repo = repo;
        }


        public RedirectToPageResult OnPost()
        {
            var mainIngredient = new MainIngredient
            {
                Ingredient = MainIngredient,
            };

            Recipe.MainIngredients.Add(mainIngredient);
            _repo.AddRecipe(Recipe);
            return RedirectToPage("ListRecipe");
        }

        public void OnGet()
        {

        }
    }
}
