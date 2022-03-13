using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class RecipeItems
    {
        [Key]
        public int RecipeItemsId { get; set; }

        public int RecipeId { get; set; }

        public ICollection<string> Ingredients { get; set; } = new HashSet<string>();

        public string IngredientName { get; set; }

        /////////////////////////////////////////

        public Recipe Recipe { get; set; }



    }
}
