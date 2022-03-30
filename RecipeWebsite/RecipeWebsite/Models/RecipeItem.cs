using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class RecipeItem
    {
        [Key]
        public int RecipeItemId { get; set; }

        public string? RecipeDirection { get; set; }

        public int? RecipeId { get; set; }


        public ICollection<string> Ingredients { get; set; } = new HashSet<string>();

        [Required]
        [Display(Name = "Recipe Item")]
        [StringLength(255)]
        public string? Item { get; set; }

        /////////////////////////////////////////

        public Recipe Recipe { get; set; }

        //public RecipeDirection? RecipeDirection { get; set; }
    }
}
