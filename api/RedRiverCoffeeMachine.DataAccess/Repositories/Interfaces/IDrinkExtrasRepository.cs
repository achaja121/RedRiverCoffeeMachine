using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces
{
    public interface IDrinkExtrasRepository
    {
        public Task<Extra> AddDrinkExtraAsync(Extra drinkExtra);
    }
}
