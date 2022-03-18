using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class RecipeComment
    {
        [Key]
        public int CommentId { get; set; }

        public int RecipeId { get; set; }

        public string SubmitterId { get; set; }

        public string Comment { get; set; }






        
        //////////////////////////

        public Recipe Recipe { get; set; }
        public RecipeUser Submitter { get; set; }
    }
}
