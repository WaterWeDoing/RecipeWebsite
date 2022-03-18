using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeWebsite.Enums;
using RecipeWebsite.Models;
using RecipeWebsite.Repositories.Interfaces;

namespace RecipeWebsite.Pages
{
    public class AddRecipeModel : PageModel
    {
        [BindProperty]
        public Recipe Recipe { get; set; }

        public SelectList MealSelect { get; set; }


        [BindProperty]
        public int PrepTimeHour { get; set; }

        [BindProperty]

        public int PrepTimeMinute { get; set; }

        [BindProperty]

        public int CookTimeHour { get; set; }

        [BindProperty]

        public int CookTimeMinute { get; set; }



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

            Recipe.PrepTime = (PrepTimeHour * 60) + PrepTimeMinute;
            Recipe.CookTime = (CookTimeHour * 60) + CookTimeMinute;

            Recipe.MainIngredients.Add(mainIngredient);
            _repo.AddRecipe(Recipe);






            return RedirectToPage("ListRecipe");
        }

        public void OnGet()
        {
            var meals = from MealEnum d in Enum.GetValues(typeof(MealEnum))
                select new { ID = (int)d, Name = d.ToString() };
            MealSelect = new SelectList(meals, "ID", "Name");
        }
    }
}
