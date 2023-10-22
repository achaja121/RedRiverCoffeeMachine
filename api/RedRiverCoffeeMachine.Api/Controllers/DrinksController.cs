using Microsoft.AspNetCore.Mvc;
using RedRiverCoffeeMachine.Api.Constants;
using RedRiverCoffeeMachine.Api.Services.Interfaces;

namespace RedRiverCoffeeMachine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinksController(
            IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet(ApiEndpoints.GetAllDrinks)]
        public async Task<IActionResult> GetAllDrinksAsync()
        {
            return Ok(await _drinkService.GetAllDrinksAsync());
        }

        [HttpGet(ApiEndpoints.GetDrinkDetails)]
        public async Task<IActionResult> GetDrinkDetailsAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ApiMessages.DrinkIdRequired);
            }

            var result = await _drinkService.GetDrinkByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }
    }
}