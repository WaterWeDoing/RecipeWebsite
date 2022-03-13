using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace RecipeWebsite.Models
{
    public class MainIngredient
    {
        [MaxLength(255), MinLength(3)]
        [Display(Name = "Main Ingredient")]
        public string Ingredient { get; set; }

        [Key]
        public int MainIngredientId { get; set; }
        public int RecipeId { get; set; }
        //////////////////////////////////////////

        public Recipe Recipe { get; set; }

    }
}
