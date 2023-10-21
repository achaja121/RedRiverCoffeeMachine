namespace RedRiverCoffeeMachine.Api.Models.Requests
{
    public class AddExtrasRequest
    {
        public string Name { get; set; }

        public List<int> DrinksId { get; set; }
    }
}
