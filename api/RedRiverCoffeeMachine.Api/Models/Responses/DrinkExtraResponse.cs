namespace RedRiverCoffeeMachine.Api.Models.Responses
{
    public class DrinkExtraResponse
    {
        public int DrinkId { get; set; }

        public IEnumerable<ExtraResponse> DrinkExtras { get; set; }
    }
}
