using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Ingredients")]
        public List<string> IngredientList { get; set; }

        public int Servings { get; set; }
    }
}
