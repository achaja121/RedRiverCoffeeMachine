using Moq;
using RedRiverCoffeeMachine.Api.Models.Responses;
using RedRiverCoffeeMachine.Api.Services;
using RedRiverCoffeeMachine.Data.Enums;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;
using Shouldly;

namespace RedRiverCoffeeMachine.Api.Tests.Services
{
    [TestFixture]
    internal class DrinkServiceTests : TestBase<DrinkService>
    {
        private const string DrinkNameOne = "Coffee";
        private const string DrinkNameTwo = "Tea";

        [Test]
        public async Task GetAllDrinksAsync_GivenRepositoryReturnsData_ReturnsDrinks()
        {
            var drinks = new List<Drink>
            {
                new Drink
                {
                    Id = 1,
                    Name = DrinkNameOne,
                },
                new Drink
                {
                    Id = 2,
                    Name = DrinkNameTwo,
                }
            };

            AutoMock.Mock<IDrinksRepository>()
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(drinks);

            var result = (await SystemUnderTest.GetAllDrinksAsync())?.ToList();

            result.ShouldNotBeNull();
            result.Count().ShouldBe(drinks.Count());
            result.FirstOrDefault(x => x.Name == DrinkNameOne && x.Id == 1).ShouldNotBeNull();
            result.FirstOrDefault(x => x.Name == DrinkNameTwo && x.Id == 2).ShouldNotBeNull();
        }

        [Test]
        public async Task GetAllDrinksAsync_GivenRepositoryReturnsNull_ReturnsEmptyEnumerable()
        {
            var result = await SystemUnderTest.GetAllDrinksAsync();

            result.ShouldBeEmpty();
        }

        [Test]
        public async Task GetDrinkByIdAsync_GivenRepositoryReturnsData_ReturnsDrinkDetails()
        {
            int id = 1;
            const string steps = "1,3,4";

            var drink = new Drink 
            { 
                Id = id,
                Name = DrinkNameOne,
                RecipeStepsOrder= steps,
                Type = DrinkTypes.Coffee
            };

            AutoMock.Mock<IDrinksRepository>()
                .Setup(x => x.GetDrinkByIdAsync(id))
                .ReturnsAsync(drink);

            var result = await SystemUnderTest.GetDrinkByIdAsync(id);

            result.ShouldNotBeNull();
            result.Type.ShouldBe(DrinkTypes.Coffee);
            result.Id.ShouldBe(id);
            result.Name.ShouldBe(DrinkNameOne);
        }

        [Test]
        public async Task GetDrinkByIdAsync_GivenRepositoryReturnsNull_ReturnsNull()
        {
            var result = await SystemUnderTest.GetDrinkByIdAsync(1);

            result.ShouldBeNull();
        }
    }
}
