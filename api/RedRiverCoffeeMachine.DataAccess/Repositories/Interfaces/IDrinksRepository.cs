using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces
{
    public interface IDrinksRepository : IRepositoryBase<Drink>
    {
        Task<Drink> GetDrinkByIdAsync(int id);

        Task<IEnumerable<Drink>> GetDrinksByIdAsync(IEnumerable<int> ids);
    }
}
