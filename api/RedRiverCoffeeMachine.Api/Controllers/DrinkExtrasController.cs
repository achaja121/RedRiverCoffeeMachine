using Microsoft.AspNetCore.Mvc;
using RedRiverCoffeeMachine.Api.Models.Requests;
using RedRiverCoffeeMachine.Api.Services.Interfaces;

namespace RedRiverCoffeeMachine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinkExtrasController : ControllerBase
    {
        private readonly IDrinkExtrasService _drinkExtrasService;
        private readonly ILogger<DrinksController> _logger;

        public DrinkExtrasController(
            IDrinkExtrasService drinkExtrasService,
            ILogger<DrinksController> logger)
        {
            _drinkExtrasService = drinkExtrasService;
            _logger = logger;
        }

        [HttpPost("addExtras")]
        public async Task<IActionResult> AddDrinkExtrasAsync(AddExtrasRequest request)
        {
            return await _drinkExtrasService.AddDrinkExtraAsync(request) ? 
                Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
