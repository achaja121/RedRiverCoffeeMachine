using RedRiverCoffeeMachine.Api.Models.Requests;

namespace RedRiverCoffeeMachine.Api.Services.Interfaces
{
    public interface IDrinkExtrasService
    {
        Task<bool> AddDrinkExtraAsync(AddExtrasRequest request);
    }
}
