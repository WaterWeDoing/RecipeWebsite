using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeWebsite.Models;
using RecipeWebsite.Repositories;
using RecipeWebsite.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace RecipeWebsite.Pages
{
    public class DisplayRecipeModel : PageModel
    {
        
        public Recipe Recipe { get; set; } = new Recipe();

        [BindProperty]
        public RecipeComment Comment { get; set; } = new RecipeComment();

        private readonly IRecipeRepo _recipeRepo;

        private readonly UserManager<RecipeUser> _userManager;



        public DisplayRecipeModel(IRecipeRepo recipe, UserManager<RecipeUser> userManager)
        {
            _recipeRepo = recipe;
            _userManager = userManager;
        }

        

        public void OnGet(int id)
        {
            Recipe = _recipeRepo.GetRecipe(id);
            Comment.RecipeId = Recipe.RecipeId;
        }

        public IActionResult OnPost()
        {
            Recipe = _recipeRepo.GetRecipe(Comment.RecipeId.Value);
            Recipe.Comments.Add(Comment);
            Comment.SubmitterId = _userManager.GetUserId(User);
            _recipeRepo.UpdateRecipe(Recipe);
            return RedirectToPage("/DisplayRecipe", new {id=Recipe.RecipeId});
        
        }


    }
}
