using Moq;
using RedRiverCoffeeMachine.Api.Models.Requests;
using RedRiverCoffeeMachine.Api.Services;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;
using Shouldly;

namespace RedRiverCoffeeMachine.Api.Tests.Services
{
    [TestFixture]
    internal class DrinkExtrasServiceTests : TestBase<DrinkExtrasService>
    {
        private const string ExtraName = "Ice";
        private const string ExtraNameTwo = "Cream";

        private static readonly List<int> _drinkIds = new List<int> { 1, 2 };

        [Test]
        public async Task AddDrinkExtraAsync_GivenExtraUpdateFails_ReturnsFalse()
        {
            var request = SetUpAddExtrasRequest(null);

            var result = await SystemUnderTest.AddDrinkExtraAsync(request);

            result.ShouldBeFalse();
        }

        [TestCaseSource(nameof(GetEmptyDrinkListData))]
        public async Task AddDrinkExtraAsync_GivenDrinksAreNullOrEmpty_ReturnsFalse(List<Drink> drinks)
        {
            var extra = new Extra 
            { 
                Name = ExtraName
            };

            var updatedExtra = new Extra
            { 
                Name = ExtraName,
                Id = 3
            };

            var request = SetUpAddExtrasRequest(extra);

            AutoMock.Mock<IDrinksRepository>()
                .Setup(x => x.GetDrinksByIdAsync(_drinkIds))
                .ReturnsAsync(drinks);

            var result = await SystemUnderTest.AddDrinkExtraAsync(request);

            result.ShouldBeFalse();
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task AddDrinkExtraAsync_GivenDrinksReturned_ReturnsExpectedResult(bool expectedResult)
        {
            var extra = new Extra
            {
                Name = ExtraName
            };

            var drinks = new List<Drink>
            {
                new Drink
                {
                    Id = 1
                },
                new Drink
                {
                    Id = 2
                }
            };

            AutoMock.Mock<IDrinksRepository>()
                .Setup(x => x.GetDrinksByIdAsync(_drinkIds))
                .ReturnsAsync(drinks);

            AutoMock.Mock<IDrinkExtrasRepository>()
                .Setup(x => x.AddRangeAsync(It.IsAny<IEnumerable<DrinkExtra>>()))
                .ReturnsAsync(expectedResult);

            var request = SetUpAddExtrasRequest(extra);

            var result = await SystemUnderTest.AddDrinkExtraAsync(request);

            result.ShouldBe(expectedResult);
        }

        [Test]
        public async Task GetDrinkExtrasAsync_GivenRepositoryRetunsDrinkExtras_returnsExpectedResponse()
        {
            var drinkId = 1;
            var extraIdOne = 1;
            var extraIdTwo = 2;

            var drinkExtras = new List<DrinkExtra>
            {
                new DrinkExtra
                {
                    DrinkId = drinkId,
                    ExtraId = extraIdOne,
                    Extra= new Extra
                    {
                        Id = extraIdOne,
                        Name = ExtraName
                    }
                },
                new DrinkExtra
                {
                    DrinkId = drinkId,
                    ExtraId = extraIdTwo,
                    Extra= new Extra
                    {
                        Id = extraIdTwo,
                        Name = ExtraNameTwo
                    }
                }
            };

            AutoMock.Mock<IDrinkExtrasRepository>()
                .Setup(x => x.GetDrinkExtrasByDrinkIdAsync(drinkId))
                .ReturnsAsync(drinkExtras);

            var result = await SystemUnderTest.GetDrinkExtrasAsync(drinkId);

            result.ShouldNotBeNull();
            result.DrinkId.ShouldBe(drinkId);
            result.DrinkExtras.FirstOrDefault(x => x.Id == extraIdOne && x.Name == ExtraName).ShouldNotBeNull();
            result.DrinkExtras.FirstOrDefault(x => x.Id == extraIdTwo && x.Name == ExtraNameTwo).ShouldNotBeNull();
        }

        [Test]
        public async Task GetDrinkExtrasAsync_GivenRepositoryReturnsNull_ReturnsResponseWithNoExtras()
        {
            var drinkId = 1;
            var result = await SystemUnderTest.GetDrinkExtrasAsync(drinkId);

            result.ShouldNotBeNull();
            result.DrinkId.ShouldBe(drinkId);
            result.DrinkExtras?.Count().ShouldBe(0);
        }

        private static List<TestCaseData> GetEmptyDrinkListData()
        {
            return new List<TestCaseData>
            {
                null,
                new TestCaseData(new List<Drink>())
            };
        }

        private AddExtrasRequest SetUpAddExtrasRequest(Extra expectedExtra)
        {
            var request = new AddExtrasRequest
            {
                Name = ExtraName,
                DrinksId = _drinkIds
            };

            AutoMock.Mock<IExtraRepository>()
                .Setup(x => x.AddExtraAsync(It.IsAny<Extra>()))
                .ReturnsAsync(expectedExtra);

            return request;
        }
    }
}
