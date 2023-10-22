using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("getSteps")]
        public async Task<IActionResult> GetRecipeStepsAsync([FromQuery(Name = ExtrasQuery)] int[] extraIds, int drinkId)
        {
            if (drinkId < 0)
            {
                return BadRequest("Drink id is required");
            }

            return Ok(await _recipeStepsService.GetRecipeStepsAsync(extraIds, drinkId));
        }
    }
}
