using System.ComponentModel.DataAnnotations;

namespace RedRiverCoffeeMachine.Data.Models
{
    public class RecipeStep
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string StepName { get; set; }
    }
}
