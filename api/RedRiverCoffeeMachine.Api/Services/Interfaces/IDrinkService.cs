using RedRiverCoffeeMachine.Api.Models.Responses;

namespace RedRiverCoffeeMachine.Api.Services.Interfaces
{
    public interface IDrinkService
    {
        Task<IEnumerable<DrinkResponse>> GetAllDrinksAsync();

        Task<DrinkDetailsResponse> GetDrinkByIdAsync(int id);
    }
}
