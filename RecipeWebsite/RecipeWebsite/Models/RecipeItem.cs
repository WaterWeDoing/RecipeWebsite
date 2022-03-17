using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class RecipeItem
    {
        [Key]
        public int RecipeItemId { get; set; }

        public int RecipeId { get; set; }

        public ICollection<string> Ingredients { get; set; } = new HashSet<string>();

        [Required]
        [Display(Name = "Ingredient")]
        [StringLength(255)]
        public string? IngredientName { get; set; }

        /////////////////////////////////////////

        public Recipe Recipe { get; set; }
    }
}
