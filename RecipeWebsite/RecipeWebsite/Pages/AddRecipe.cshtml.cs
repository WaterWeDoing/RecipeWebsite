using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeWebsite.Enums;
using RecipeWebsite.Models;
using RecipeWebsite.Repositories.Interfaces;
using RecipeWebsite.Services.Interfaces;

namespace RecipeWebsite.Pages
{
    public class AddRecipeModel : PageModel
    {
        [BindProperty]
        public Recipe Recipe { get; set; } = new ();

        public SelectList MealSelect { get; set; }


        [BindProperty]
        [Display(Name="Preparation Hours")]
        public int PrepTimeHour { get; set; }

        [BindProperty]
        [Display(Name = "Preparation Minutes")]

        public int PrepTimeMinute { get; set; }

        [BindProperty]
        [Display(Name = "Cook Hours")]

        public int CookTimeHour { get; set; }

        [BindProperty]
        [Display(Name = "Cook Minutes")]

        public int CookTimeMinute { get; set; }

        [BindProperty]
        public List<string> RecipeItems { get; set; }

        private readonly IRecipeRepo _repo;

        private readonly UserManager<RecipeUser> _userManager;

        private readonly IImageService _imageService;

        [BindProperty]
        [Display(Name = "Main Ingredient")]
        public string MainIngredient { get; set; }

        public AddRecipeModel(IRecipeRepo repo, UserManager<RecipeUser> userManager, IImageService imageService)
        {
            _repo = repo;
            _userManager = userManager;
            _imageService = imageService;
        }




        public async Task<RedirectToPageResult> OnPost()
        {
            Recipe.SubmitterId = _userManager.GetUserId(User);
            Recipe.PhotoImage = await _imageService.EncodeImageAsync(Recipe.FormFile);
            Recipe.ContentType = _imageService.ContentType(Recipe.FormFile);


            var mainIngredient = new MainIngredient
            {
                Ingredient = MainIngredient,
            };

            Recipe.PrepTime = (PrepTimeHour * 60) + PrepTimeMinute;
            Recipe.CookTime = (CookTimeHour * 60) + CookTimeMinute;

            Recipe.MainIngredients.Add(mainIngredient);
            foreach (var recipeRecipeItem in RecipeItems)
            {
                var recipe = new RecipeItem() {Item = recipeRecipeItem};
                Recipe.RecipeItems.Add(recipe);
            }
            _repo.AddRecipe(Recipe);






            return RedirectToPage("ItemIngredients", new {Id = Recipe.RecipeId} );
        }

        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new {returnUrl="/AddRecipe", area = "Identity"});
            }

            var meals = from MealEnum d in Enum.GetValues(typeof(MealEnum))
                select new { ID = (int)d, Name = d.ToString() };
            MealSelect = new SelectList(meals, "ID", "Name");
            return Page();
        }
    }
}
