namespace RecipeBox.Models
{
  public class TagRecipes
  {
    public int TagRecipeId { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
  }
}