using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces
{
    public interface IRecipeStepsRepository
    {
        Task<IEnumerable<RecipeStep>> GetRecipeStepsAsync(IEnumerable<int> stepIds);
    }
}
