using System.ComponentModel.DataAnnotations;

namespace RedRiverCoffeeMachine.Data.Models
{
    public class DrinkExtra
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
