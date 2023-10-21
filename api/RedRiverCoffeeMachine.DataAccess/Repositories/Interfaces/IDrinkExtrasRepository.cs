using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces
{
    public interface IDrinkExtrasRepository
    {
        public Task<DrinkExtra> AddDrinkExtraAsync(DrinkExtra drinkExtra);
    }
}
