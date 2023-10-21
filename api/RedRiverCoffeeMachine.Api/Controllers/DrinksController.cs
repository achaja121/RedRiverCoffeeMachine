using Microsoft.AspNetCore.Mvc;
using RedRiverCoffeeMachine.Api.Services.Interfaces;

namespace RedRiverCoffeeMachine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService _drinkService;
        private readonly ILogger<DrinksController> _logger;

        public DrinksController(
            IDrinkService drinkService,
            ILogger<DrinksController> logger)
        {
            _drinkService = drinkService;
            _logger = logger;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllDrinksAsync()
        {
            return Ok(await _drinkService.GetAllDrinksAsync());
        }

        [HttpGet("drinkDetails")]
        public async Task<IActionResult> GetDrinkDetailsAsync(int Id)
        {
            return Ok(await _drinkService.GetDrinkByIdAsync(Id));
        }
    }
}