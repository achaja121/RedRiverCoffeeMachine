using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Models;

namespace RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces
{
    public interface IDrinkExtrasRepository : IRepositoryBase<DrinkExtra>
    {
        Task<IEnumerable<DrinkExtra>> GetDrinkExtrasByDrinkIdAsync(int drinkId);
    }
}
