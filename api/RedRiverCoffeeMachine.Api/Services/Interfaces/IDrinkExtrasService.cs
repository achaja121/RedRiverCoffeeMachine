using RedRiverCoffeeMachine.Api.Models.Requests;
using RedRiverCoffeeMachine.Api.Models.Responses;

namespace RedRiverCoffeeMachine.Api.Services.Interfaces
{
    public interface IDrinkExtrasService
    {
        Task<bool> AddDrinkExtraAsync(AddExtrasRequest request);

        Task<DrinkExtraResponse> GetDrinkExtrasAsync(int drinkId);
    }
}
