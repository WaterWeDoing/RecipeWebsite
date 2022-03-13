using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebsite.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Required]
        [MaxLength(255), MinLength(3)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string? Description { get; set; }

        [Display(Name = "Ingredients")]
        public ICollection<string> IngredientList { get; set; } = new HashSet<string>();

        public int? Servings { get; set; }
        /////////////////////

        public ICollection<MainIngredient> MainIngredient { get; set; } = new HashSet<MainIngredient>();
    }

}
