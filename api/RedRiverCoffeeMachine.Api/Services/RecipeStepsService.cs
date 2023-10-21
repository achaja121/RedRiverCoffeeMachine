using RedRiverCoffeeMachine.Api.Models.Responses;
using RedRiverCoffeeMachine.Api.Services.Interfaces;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.Api.Services
{
    public class RecipeStepsService : IRecipeStepsService
    {
        private readonly IDrinksRepository _drinksRepository;
        private readonly ILogger<RecipeStepsService> _logger;
        private readonly IRecipeStepsRepository _recipeStepsRepository;

        public RecipeStepsService(
            IDrinksRepository drinksRepository,
            ILogger<RecipeStepsService> logger,
            IRecipeStepsRepository recipeStepsRepository) 
        {
            _drinksRepository = drinksRepository;
            _logger = logger;
            _recipeStepsRepository = recipeStepsRepository;
        }

        public async Task<RecipeStepsResponse> GetRecipeStepsAsync(int drinkId)
        {
            var drink = await _drinksRepository.GetDrinkByIdAsync(drinkId);

            return new RecipeStepsResponse
            {
                DrinkName = drink.Name,
                RecipeSteps = await GetRecipeStepsAsync(drink.RecipeStepsOrder),
            };
        }

        private async Task<List<string>> GetRecipeStepsAsync(string stepIds)
        {
            var recipeStepsList = new List<string>();

            if(string.IsNullOrEmpty(stepIds))
            {
                _logger.LogWarning("");

                return recipeStepsList;
            }

            var stepIdList = GetStepIds(stepIds);
            var steps = await _recipeStepsRepository.GetRecipeStepsAsync(stepIdList);

            foreach ( var stepId in stepIdList)
            {
                var step = steps.FirstOrDefault(x => x.Id == stepId);
                
                if (step == null)
                {
                    _logger.LogWarning("");
                    continue;
                }

                recipeStepsList.Add(step.StepName);
            }

            return recipeStepsList;
        }

        private static List<int> GetStepIds(string stepIdsString)
        {
            var stepIds = new List<int>();

            if (string.IsNullOrEmpty(stepIdsString))
            {
                return stepIds;
            }

            var idsStringArray = stepIdsString.Split(',');

            foreach( var id in idsStringArray)
            {
                stepIds.Add(int.Parse(id));
            }

            return stepIds;
        } 
    }
}
