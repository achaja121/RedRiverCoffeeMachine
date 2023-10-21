using RedRiverCoffeeMachine.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace RedRiverCoffeeMachine.Data.Models
{
    public  class Drink
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DrinkTypes Type { get; set; }

        public List<DrinkExtra> PossibleExtras { get; set; } = new List<DrinkExtra>();

        [MaxLength(20)]
        public string RecipeStepsOrder { get; set; }
    }
}
