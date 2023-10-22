using RedRiverCoffeeMachine.Data.DataAccess;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.DataAccess.Repositories
{
    public class RecipeStepsRepository : RepositoryBase<RecipeStep>, IRecipeStepsRepository
    {
        public RecipeStepsRepository(DrinksContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RecipeStep>> GetRecipeStepsByIdAsync(IEnumerable<int> ids)
        {
            return await FindByConditionAsync(x => ids.Any(id => id == x.Id));
        }
    }
}
