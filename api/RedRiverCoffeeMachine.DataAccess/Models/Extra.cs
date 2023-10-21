using RedRiverCoffeeMachine.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace RedRiverCoffeeMachine.Data.Models
{
    public class Extra
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<DrinkExtra> DrinkExtras { get; set; }
    }
}
