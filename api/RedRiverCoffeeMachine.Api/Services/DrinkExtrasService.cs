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
        private readonly IExtraRepository _extraRepository;
        private readonly IDrinkExtrasRepository _drinkExtrasRepository;
        private readonly IDrinksRepository _drinksRepository;

        public DrinkExtrasService(
            IExtraRepository extraRepository,
            IDrinkExtrasRepository drinkExtrasRepository, 
            IDrinksRepository drinksRepository) 
        {
            _extraRepository = extraRepository;
            _drinkExtrasRepository = drinkExtrasRepository;
            _drinksRepository= drinksRepository;
        }
        
        public async Task<bool> AddDrinkExtraAsync(AddExtrasRequest request)
        {
            var extra = new Extra
            {
                Name = request.Name,
            };

            var updatedExtra = await _extraRepository.AddExtraAsync(extra);

            if(updatedExtra == null)
            {
                return false;
            }

            var drinks = await _drinksRepository.GetDrinksByIdAsync(request.DrinksId);

            var drinkExtras = drinks.Select(drink => new DrinkExtra
            {
                ExtraId = updatedExtra.Id,
                DrinkId = drink.Id,
            });
            
            return await _drinkExtrasRepository.AddRangeAsync(drinkExtras);
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
