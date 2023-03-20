using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    [Required(ErrorMessage = "Please add a recipe name!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please add the ingredients!")]
    public string Ingredients { get; set; }
    [Required(ErrorMessage = "Please add the instructions!")]
    public string Instructions { get; set; }
    public List<TagRecipe> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}