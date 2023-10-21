using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.DataAccess.Models
{
    public class DrinkExtra
    {
        public int DrinkId { get; set; }
        public int ExtraId { get; set; }
        public Drink Drink { get; set; }
        public Extra Extra { get; set; }
    }
}
