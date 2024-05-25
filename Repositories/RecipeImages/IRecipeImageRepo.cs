
using Models.RecipeImages;
using Models.Recipes;

namespace Repositories.RecipeImages;

public interface IRecipeImageRepo
{
    Task Create(Recipe recipe, ICollection<IFormFile> files);

    Task Delete(int id);

    Task<RecipeImage> FindById(int id);
}