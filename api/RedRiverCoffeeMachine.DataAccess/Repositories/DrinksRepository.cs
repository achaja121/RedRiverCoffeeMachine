using RedRiverCoffeeMachine.Data.DataAccess;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.DataAccess.Repositories
{
    public class DrinksRepository : RepositoryBase<Drink>, IDrinksRepository
    {
        public DrinksRepository(DrinksContext context) : base(context) 
        {
        }

        public async Task<Drink> GetDrinkByIdAsync(int id)
        {
            return await FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Drink>> GetDrinksByIdAsync(IEnumerable<int> ids)
        {
            return await FindByConditionAsync(x => ids.Any(id => id == x.Id));
        }
    }
}
