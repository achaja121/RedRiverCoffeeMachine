using System.ComponentModel.DataAnnotations;

namespace RedRiverCoffeeMachine.Api.Models.Requests
{
    public class AddExtrasRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public List<int> DrinksId { get; set; }
    }
}
