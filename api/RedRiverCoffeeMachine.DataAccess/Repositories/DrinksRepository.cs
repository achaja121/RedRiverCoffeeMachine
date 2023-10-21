using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.DataAccess.Repositories
{
    public class DrinksRepository : IDrinksRepository
    {
        public Task<IEnumerable<Drink>> GetAllDrinksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Drink> GetDrinkByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Drink>> GetDrinksByIdAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDrinkAsync(Drink drink)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDrinksAsync(IEnumerable<Drink> drinks)
        {
            throw new NotImplementedException();
        }
    }
}
