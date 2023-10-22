using Microsoft.AspNetCore.Mvc;
using RedRiverCoffeeMachine.Api.Constants;
using RedRiverCoffeeMachine.Api.Services.Interfaces;

namespace RedRiverCoffeeMachine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeStepsController : ControllerBase
    {
        private const string ExtrasQuery = "extraIds";

        private readonly IRecipeStepsService _recipeStepsService;

        public RecipeStepsController(IRecipeStepsService recipeStepsService)
        {
            _recipeStepsService = recipeStepsService;
        }

        [HttpGet(ApiEndpoints.GetRecipeSteps)]
        public async Task<IActionResult> GetRecipeStepsAsync([FromQuery(Name = ExtrasQuery)] int[] extraIds, int drinkId)
        {
            if (drinkId <= 0)
            {
                return BadRequest(ApiMessages.DrinkIdRequired);
            }

            return Ok(await _recipeStepsService.GetRecipeStepsAsync(extraIds, drinkId));
        }
    }
}
