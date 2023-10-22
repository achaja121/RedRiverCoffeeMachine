using Microsoft.AspNetCore.Mvc;
using RedRiverCoffeeMachine.Api.Models.Requests;
using RedRiverCoffeeMachine.Api.Services.Interfaces;

namespace RedRiverCoffeeMachine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkExtrasController : ControllerBase
    {
        private readonly IDrinkExtrasService _drinkExtrasService;

        public DrinkExtrasController(
            IDrinkExtrasService drinkExtrasService)
        {
            _drinkExtrasService = drinkExtrasService;
        }

        [HttpPost("addExtras")]
        public async Task<IActionResult> AddDrinkExtrasAsync(AddExtrasRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name cannot be whitespace");
            }

            if (!request.DrinksId.Any())
            {
                return BadRequest("At least one drink id must be provided");
            }

            return await _drinkExtrasService.AddDrinkExtraAsync(request) ? 
                Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("getExtras")]
        public async Task<IActionResult> GetDrinkExtras(int drinkId)
        {
            if(drinkId < 0)
            {
                return BadRequest("Drink id is required");
            }

            return Ok(await _drinkExtrasService.GetDrinkExtrasAsync(drinkId));
        }
    }
}
