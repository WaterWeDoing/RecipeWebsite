using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class RecipeRating
    {
        [Key]
        public int RatingId { get; set; }

        public int RecipeId { get; set; }

        [Range(1,5)]
        public int UserRating { get; set; }

        ////////////////////////////////////////////////

        public Recipe Recipe { get; set; }

    }
}
