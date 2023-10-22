using RedRiverCoffeeMachine.Data.Enums;
using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.Api.Models.Responses
{
    public class DrinkDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DrinkTypes Type { get; set; }
    }
}
