using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebsite.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required]
        [MaxLength(255), MinLength(3)]
        public string? Name { get; set; }
        
        [MaxLength(2500)]
        [Display(Name = "Description")]
        public string? LongDescription { get; set; }

        public int? Servings { get; set; }

        [MaxLength(100), MinLength(5)]
        [Display(Name = "Short Description")]
        [Required]
        public string? ShortDescription { get; set; }

        [MaxLength(20)]
        public string? Meal { get; set; }

        [Display(Name = "Preparation Time")]
        public TimeSpan PrepTime{ get; set; }

        [Display(Name = "Cooking Time")]
        public TimeSpan CookTime { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }


        ///////////////////// Navigation Properties

        public ICollection<RecipeRating> RecipeRatings { get; set; } = new HashSet<RecipeRating>();

        public ICollection<MainIngredient> MainIngredients { get; set; } = new HashSet<MainIngredient>();

        public ICollection<RecipeItem> RecipeItems { get; set; } = new HashSet<RecipeItem>();

    }

}
