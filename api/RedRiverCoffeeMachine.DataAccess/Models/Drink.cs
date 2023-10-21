using RedRiverCoffeeMachine.Data.Enums;

namespace RedRiverCoffeeMachine.Data.Models
{
    public  class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DrinkTypes Type { get; set; }
        public List<DrinkExtra> PossibleExtras { get; set; } = new List<DrinkExtra>();
        public string RecipeStepsOrder { get; set; }
    }
}
