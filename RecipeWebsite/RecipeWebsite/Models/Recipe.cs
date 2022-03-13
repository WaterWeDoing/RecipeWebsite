using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255), MinLength(3)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Display(Name = "Ingredients")]
        public ICollection<string> IngredientList { get; set; } = new HashSet<string>();

        public int? Servings { get; set; }
    }

}
