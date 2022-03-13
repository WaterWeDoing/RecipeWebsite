namespace RecipeWebsite.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<string> IngredientList { get; set; }
        public int Servings { get; set; }
        public string  Description { get; set; }

        public int Id { get; set; }
    }
}
