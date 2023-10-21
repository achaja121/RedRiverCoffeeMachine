using Microsoft.AspNetCore.Mvc;

namespace RedRiverCoffeeMachine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly ILogger<DrinksController> _logger;

        public DrinksController(ILogger<DrinksController> logger)
        {
            _logger = logger;
        }
    }
}