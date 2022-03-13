using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeWebsite.Models;
using RecipeWebsite.Services;

namespace RecipeWebsite.Pages
{
    public class ListRecipeModel : PageModel
    {
        public IEnumerable<Recipe> Recipes = new List<Recipe>();

		private readonly IRecipeRepo _repo;

		public ListRecipeModel(IRecipeRepo repo)
		{
			_repo = repo;
		}

        public void OnGet()
        {
            Recipes = _repo.GetAllRecipes();
        }
    }
}
