using Microsoft.AspNetCore.Mvc;
using RedRiverCoffeeMachine.Api.Constants;
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

        [HttpPost(ApiEndpoints.AddExtras)]
        public async Task<IActionResult> AddDrinkExtrasAsync(AddExtrasRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest(ApiMessages.NameCannotBeWhiteSpace);
            }

            if (!request.DrinksId.Any())
            {
                return BadRequest(ApiMessages.AtLeasOneDrinkIdRequired);
            }

            return await _drinkExtrasService.AddDrinkExtraAsync(request) ? 
                Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet(ApiEndpoints.GetExtras)]
        public async Task<IActionResult> GetDrinkExtras(int drinkId)
        {
            if(drinkId <= 0)
            {
                return BadRequest(ApiMessages.DrinkIdRequired);
            }

            return Ok(await _drinkExtrasService.GetDrinkExtrasAsync(drinkId));
        }
    }
}
