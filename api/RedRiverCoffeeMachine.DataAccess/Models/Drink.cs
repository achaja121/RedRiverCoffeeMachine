using RedRiverCoffeeMachine.Data.Enums;
using RedRiverCoffeeMachine.DataAccess.Models;
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

        [MaxLength(20)]
        public string RecipeStepsOrder { get; set; }

        public ICollection<DrinkExtra> DrinkExtras { get; set; } 
    }
}
