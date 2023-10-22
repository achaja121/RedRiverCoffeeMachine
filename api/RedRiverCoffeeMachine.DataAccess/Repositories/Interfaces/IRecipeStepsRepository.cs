using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces
{
    public interface IRecipeStepsRepository : IRepositoryBase<RecipeStep>
    {
        Task<IEnumerable<RecipeStep>> GetRecipeStepsByIdAsync(IEnumerable<int> stepIds);
    }
}
