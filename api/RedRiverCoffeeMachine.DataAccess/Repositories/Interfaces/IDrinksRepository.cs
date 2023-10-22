using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces
{
    public interface IDrinksRepository : IRepositoryBase<Drink>
    {
        Task<IEnumerable<Drink>> GetAllDrinksAsync();

        Task<Drink> GetDrinkByIdAsync(int id);

        Task<IEnumerable<Drink>> GetDrinksByIdAsync(IEnumerable<int> ids);

        Task<bool> UpdateDrinkAsync(Drink drink);

        Task<bool> UpdateDrinksAsync(IEnumerable<Drink> drinks);
    }
}
