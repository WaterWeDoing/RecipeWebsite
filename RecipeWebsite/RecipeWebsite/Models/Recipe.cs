using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebsite.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required]
        public string? SubmitterId { get; set; }

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

        [NotMapped]
        [Display(Name = "Recipe Image")]
        public IFormFile? FormFile { get; set; }

        public byte[]? PhotoImage { get; set; }
        
        [MaxLength(50)]
        public string? ContentType { get; set; }



        [MaxLength(20)]
        public string? Meal { get; set; }

        [Display(Name = "Preparation Time")]
        public int PrepTime{ get; set; }

        [Display(Name = "Cooking Time")]
        public int CookTime { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }


        ///////////////////// Navigation Properties

        public RecipeUser? Submitter { get; set; }

        public ICollection<RecipeRating> RecipeRatings { get; set; } = new HashSet<RecipeRating>();

        public ICollection<MainIngredient> MainIngredients { get; set; } = new HashSet<MainIngredient>();

        [Display(Name="Items")]
        public ICollection<RecipeItem> RecipeItems { get; set; } = new HashSet<RecipeItem>();

    }

}
