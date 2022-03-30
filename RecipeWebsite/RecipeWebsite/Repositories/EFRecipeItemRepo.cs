using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Models;
using RecipeWebsite.Repositories.Interfaces;

namespace RecipeWebsite.Repositories
{
    public class EFRecipeItemRepo : IRecipeItemRepo
    {
        private readonly RecipeDbContext _context;

        public EFRecipeItemRepo(RecipeDbContext context)
        {
            _context = context;
        }

        public RecipeItem? GetRecipeItem(int id)
        {
            RecipeItem? item = _context.RecipeItems
                .Where(ri => ri.RecipeItemId == id)
                .Include(ri => ri.Recipe)
                .SingleOrDefault();

            return item;
        }


        public void SaveRecipeItem(RecipeItem recipeItem)
        {
            _context.RecipeItems.Update(recipeItem);
            _context.SaveChanges();
        }




    }
}
