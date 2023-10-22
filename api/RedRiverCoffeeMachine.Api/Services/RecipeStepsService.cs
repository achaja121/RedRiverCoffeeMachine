using RedRiverCoffeeMachine.Api.Models.Responses;
using RedRiverCoffeeMachine.Api.Services.Interfaces;
using RedRiverCoffeeMachine.Data.Enums;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.Api.Services
{
    public class RecipeStepsService : IRecipeStepsService
    {
        private readonly IDrinksRepository _drinksRepository;
        private readonly ILogger<RecipeStepsService> _logger;
        private readonly IRecipeStepsRepository _recipeStepsRepository;

        private const string DrinkExtrasToken = "{drinkExtras}";
        private const string DrinkTypeToken = "{drinkType}";

        public RecipeStepsService(
            IDrinksRepository drinksRepository,
            ILogger<RecipeStepsService> logger,
            IRecipeStepsRepository recipeStepsRepository) 
        {
            _drinksRepository = drinksRepository;
            _logger = logger;
            _recipeStepsRepository = recipeStepsRepository;
        }

        public async Task<RecipeStepsResponse> GetRecipeStepsAsync(int[] extraIds, int drinkId)
        {
            var drink = await _drinksRepository.GetDrinkByIdAsync(drinkId);

            return new RecipeStepsResponse
            {
                DrinkName = drink.Name,
                RecipeSteps = await GetRecipeStepsAsync(drink.RecipeStepsOrder, drink.Type),
            };
        }

        private async Task<List<string>> GetRecipeStepsAsync(string stepIds, DrinkTypes drinkType)
        {
            var recipeStepsList = new List<string>();

            if(string.IsNullOrEmpty(stepIds))
            {
                _logger.LogWarning("");

                return new List<string>();
            }

            var stepIdList = GetStepIds(stepIds);
            var steps = (await _recipeStepsRepository.GetRecipeStepsByIdAsync(stepIdList))?.ToList();

            foreach (var stepId in stepIdList)
            {
                var step = steps.FirstOrDefault(x => x.Id == stepId);
                var stepName = step.StepName;
                
                if (step == null || string.IsNullOrEmpty(stepName))
                {
                    _logger.LogWarning("");
                    continue;
                }

                if (stepName.Contains(DrinkTypeToken))
                {
                    var formatedStep = stepName.Replace(DrinkTypeToken, drinkType.ToString());
                    recipeStepsList.Add(formatedStep);

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
