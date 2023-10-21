using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.DataAccess.Repositories
{
    public class RecipeStepsRepository : IRecipeStepsRepository
    {
        public Task<IEnumerable<RecipeStep>> GetRecipeStepsAsync(IEnumerable<int> stepIds)
        {
            throw new NotImplementedException();
        }
    }
}
