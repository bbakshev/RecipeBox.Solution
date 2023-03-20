using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Tag
    {
        public int TagId { get; set; }
        [Required(ErrorMessage = "Please add a tag name!")]
        public string Title { get; set; }
        public List<TagRecipe> JoinEntities { get;}
    }
}