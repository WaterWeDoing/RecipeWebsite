using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace RecipeWebsite.Models
{
    public class MainIngredient
    {
        [Key]
        public int MainIngredientId { get; set; }

        public int RecipeId { get; set; }

        [MaxLength(255), MinLength(3)]
        [Display(Name = "Main Ingredient")]
        [Required]
        public string? Ingredient { get; set; }


        //////////////////////////////////////////

        public Recipe Recipe { get; set; }

    }
}
