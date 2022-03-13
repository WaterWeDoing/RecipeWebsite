using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeWebsite.Models;
using RecipeWebsite.Services;

namespace RecipeWebsite.Pages
{
    public class AddRecipeModel : PageModel
    {
        [BindProperty]
        public Recipe Recipe { get; set; }

		private readonly IRecipeRepo _repo;


        public AddRecipeModel(IRecipeRepo repo)
        {
            _repo = repo;
        }


        public RedirectToPageResult OnPost()
        {
            _repo.AddRecipe(Recipe);
            return RedirectToPage("ListRecipe");
        }

        public void OnGet()
        {

        }

        

    }

}
