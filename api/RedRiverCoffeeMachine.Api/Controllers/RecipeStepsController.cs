using Microsoft.AspNetCore.Mvc;
using RedRiverCoffeeMachine.Api.Services.Interfaces;

namespace RedRiverCoffeeMachine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeStepsController : ControllerBase
    {
        private readonly ILogger<DrinksController> _logger;
        private readonly IRecipeStepsService _recipeStepsService;

        public RecipeStepsController(ILogger<DrinksController> logger, IRecipeStepsService recipeStepsService)
        {
            _logger = logger;
            _recipeStepsService = recipeStepsService;
        }

        [HttpGet("getSteps")]
        public async Task<IActionResult> GetRecipeStepsAsync(int drinkId)
        {
            return Ok(await _recipeStepsService.GetRecipeStepsAsync(drinkId));
        }
    }
}
