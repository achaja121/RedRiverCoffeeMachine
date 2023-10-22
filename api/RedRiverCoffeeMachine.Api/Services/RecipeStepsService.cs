using RedRiverCoffeeMachine.Api.Models.Responses;
using RedRiverCoffeeMachine.Api.Services.Interfaces;
using RedRiverCoffeeMachine.Data.Enums;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.Api.Services
{
    public class RecipeStepsService : IRecipeStepsService
    {
        private const string DrinkExtrasToken = "{drinkExtras}";
        private const string DrinkTypeToken = "{drinkType}";

        private static readonly char _separator = ',';

        private readonly IDrinkExtrasRepository _drinkExtrasRepository;
        private readonly IDrinksRepository _drinksRepository;
        private readonly ILogger<RecipeStepsService> _logger;
        private readonly IRecipeStepsRepository _recipeStepsRepository;

        public RecipeStepsService(
            IDrinkExtrasRepository drinkExtrasRepository,
            IDrinksRepository drinksRepository,
            ILogger<RecipeStepsService> logger,
            IRecipeStepsRepository recipeStepsRepository) 
        {
            _drinkExtrasRepository = drinkExtrasRepository;
            _drinksRepository = drinksRepository;
            _logger = logger;
            _recipeStepsRepository = recipeStepsRepository;
        }

        public async Task<RecipeStepsResponse> GetRecipeStepsAsync(int[] selectedExtreIds, int drinkId)
        {
            var drink = await _drinksRepository.GetDrinkByIdAsync(drinkId);

            if(drink == null)
            {
                _logger.LogError($"{nameof(GetRecipeStepsAsync)}: Failed to get drink, drink id: {drinkId}");
                return new RecipeStepsResponse();
            }

            return new RecipeStepsResponse
            {
                DrinkName = drink.Name,
                RecipeSteps = await GetRecipeStepsAsync(selectedExtreIds, drink.RecipeStepsOrder, drink.Type, drinkId),
            };
        }

        private string FormatStepWithDrinkExtras(string step, IEnumerable<DrinkExtra> drinkExtras)
        {
            var extraNames = drinkExtras.Select(x => x.Extra.Name).Where(e => !string.IsNullOrEmpty(e)).ToArray() ?? Array.Empty<string>();

            string formattedExtras = extraNames.Count() > 1
                ? string.Join(", ", extraNames.Take(extraNames.Count() - 1)) + " and " + extraNames.Last()
                : extraNames.FirstOrDefault();

            return step.Replace(DrinkExtrasToken, formattedExtras);
        }

        private async Task<List<string>> GetRecipeStepsAsync(int[] selectedExtreIds, string stepIds, DrinkTypes drinkType, int drinkId)
        {
            if(string.IsNullOrEmpty(stepIds))
            {
                _logger.LogWarning($"Drink does not have steps, drink id: {drinkId}");

                return new List<string>();
            }

            var stepIdList = GetStepIds(stepIds);
            var steps = await _recipeStepsRepository.GetRecipeStepsByIdAsync(stepIdList);
            var drinkExtras =  await _drinkExtrasRepository.GetDrinkExtrasByExtraIdAsync(drinkId, selectedExtreIds);

            return GetFormattedSteps(stepIdList, steps, drinkExtras, drinkType);
        }

        private List<string> GetFormattedSteps(List<int> stepIds, IEnumerable<RecipeStep> recipeSteps, IEnumerable<DrinkExtra> drinkExtras, DrinkTypes drinkType)
        {
            var formattedSteps = new List<string>();

            foreach (var stepId in stepIds)
            {
                var step = recipeSteps?.FirstOrDefault(x => x.Id == stepId);
                var stepName = step?.StepName;

                if (step == null || string.IsNullOrEmpty(stepName))
                {
                    continue;
                }

                if (stepName.Contains(DrinkTypeToken))
                {
                    var formatedStep = stepName.Replace(DrinkTypeToken, drinkType.ToString());
                    formattedSteps.Add(formatedStep);

                    continue;
                }

                if(stepName.Contains(DrinkExtrasToken))
                {
                    if(drinkExtras == null || !drinkExtras.Any())
                    {
                        continue;
                    }

                    formattedSteps.Add(FormatStepWithDrinkExtras(stepName, drinkExtras));

                    continue;
                }

                formattedSteps.Add(stepName);
            }

            return formattedSteps;
        }

        private List<int> GetStepIds(string stepIdsString)
        {
            var stepIds = new List<int>();
            if (string.IsNullOrEmpty(stepIdsString))
            {
                return stepIds;
            }

            var idsStringArray = stepIdsString.Split(_separator);

            foreach( var id in idsStringArray)
            {
                var isSuccess = int.TryParse(id, out int parsedId);

                if (!isSuccess)
                {
                    _logger.LogInformation($"{nameof(GetStepIds)}: Could not parse following string: {id}");
                    continue;
                }

                stepIds.Add(parsedId);
            }

            return stepIds;
        } 
    }
}
