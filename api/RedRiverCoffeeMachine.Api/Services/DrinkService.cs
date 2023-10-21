using RedRiverCoffeeMachine.Api.Controllers;
using RedRiverCoffeeMachine.Api.Models.Responses;
using RedRiverCoffeeMachine.Api.Services.Interfaces;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.Api.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IDrinksRepository _drinksRepositry;
        private readonly ILogger<DrinkService> _logger;

        public DrinkService(
            IDrinksRepository drinksRepository, 
            ILogger<DrinkService> logger) 
        { 
            _drinksRepositry = drinksRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<DrinkResponse>> GetAllDrinksAsync()
        {
            var drinks = await _drinksRepositry.GetAllDrinksAsync();

            return drinks.Select(drink => new DrinkResponse
            {
                Id= drink.Id,
                Name = drink.Name,
            });
        }

        public async Task<DrinkDetailsResponse> GetDrinkByIdAsync(int id)
        {
            var drink = await _drinksRepositry.GetDrinkByIdAsync(id);

            return new DrinkDetailsResponse
            {
                Id= drink.Id,
                Name = drink.Name,
                Type= drink.Type,
                PossibleExtras = drink.PossibleExtras,
            };
        }
    }
}
