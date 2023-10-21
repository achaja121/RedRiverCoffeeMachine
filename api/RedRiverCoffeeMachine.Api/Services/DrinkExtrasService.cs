using RedRiverCoffeeMachine.Api.Models.Requests;
using RedRiverCoffeeMachine.Api.Services.Interfaces;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.Api.Services
{
    public class DrinkExtrasService : IDrinkExtrasService
    {
        private readonly IDrinkExtrasRepository _drinkExtrasRepository;
        private readonly IDrinksRepository _drinksRepository;

        public DrinkExtrasService(
            IDrinkExtrasRepository drinkExtrasRepository, 
            IDrinksRepository drinksRepository) 
        {
            _drinkExtrasRepository = drinkExtrasRepository;
            _drinksRepository= drinksRepository;
        }

        public async Task<bool> AddDrinkExtraAsync(AddExtrasRequest request)
        {
            var drinkExtra = new DrinkExtra
            {
                Name = request.Name,
            };

            var updatedDrinkExtra = await _drinkExtrasRepository.AddDrinkExtraAsync(drinkExtra);

            if(updatedDrinkExtra == null)
            {
                return false;
            }

            var drinks = await _drinksRepository.GetDrinksByIdAsync(request.DrinksId);

            foreach(var drink in drinks)
            {
                drink.PossibleExtras.Add(drinkExtra);
            }

            return await _drinksRepository.UpdateDrinksAsync(drinks);
        }
    }
}
