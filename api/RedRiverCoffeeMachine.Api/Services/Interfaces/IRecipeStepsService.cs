using RedRiverCoffeeMachine.Api.Models.Responses;

namespace RedRiverCoffeeMachine.Api.Services.Interfaces
{
    public interface IRecipeStepsService
    {
        public Task<RecipeStepsResponse> GetRecipeStepsAsync(int[] extraIds, int drinkId);
    }
}
