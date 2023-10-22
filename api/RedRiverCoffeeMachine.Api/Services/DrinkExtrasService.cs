using Microsoft.AspNetCore.Identity;
using RedRiverCoffeeMachine.Api.Models.Requests;
using RedRiverCoffeeMachine.Api.Models.Responses;
using RedRiverCoffeeMachine.Api.Services.Interfaces;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Models;
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
            var drinkExtra = new Extra
            {
                Name = request.Name,
            };

            var updatedDrinkExtra = "";//await _drinkExtrasRepository.AddDrinkExtraAsync(drinkExtra);

            if(updatedDrinkExtra == null)
            {
                return false;
            }

            var drinks = await _drinksRepository.GetDrinksByIdAsync(request.DrinksId);

            foreach(var drink in drinks)
            {
                //TODO rethink the way extras are updated
                //drink.DrinkExtras.Add(drinkExtra);
            }

            return await _drinksRepository.UpdateDrinksAsync(drinks);
        }

        public async Task<DrinkExtraResponse> GetDrinkExtrasAsync(int drinkId)
        {
            var drinkExtras = await _drinkExtrasRepository.GetDrinkExtrasByDrinkIdAsync(drinkId);

            return new DrinkExtraResponse
            {
                DrinkId = drinkId,
                DrinkExtras = drinkExtras?.Select(x => GetExtraResponse(x.Extra))
            };
        }

        private ExtraResponse GetExtraResponse(Extra extra)
        {
            return new ExtraResponse
            {
                Id = extra.Id,
                Name = extra.Name,
            };
        }
    }
}
