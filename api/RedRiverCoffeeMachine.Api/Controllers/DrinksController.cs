using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllDrinksAsync()
        {
            return Ok(await _drinkService.GetAllDrinksAsync());
        }

        [HttpGet("drinkDetails")]
        public async Task<IActionResult> GetDrinkDetailsAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Drink id is required");
            }

            return Ok(await _drinkService.GetDrinkByIdAsync(id));
        }
    }
}