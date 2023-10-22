using Moq;
using RedRiverCoffeeMachine.Api.Services;
using RedRiverCoffeeMachine.Data.Enums;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;
using Shouldly;

namespace RedRiverCoffeeMachine.Api.Tests.Services
{
    [TestFixture]
    internal class RecipeStepsServiceTests : TestBase<RecipeStepsService>
    {
        private const string DrinkName = "Tea";
        private const string StepOne = "Boil some water";
        private const string StepTwo = "Steep the water in the tea";
        private const string StepThree = "Pour {drinkType} in the cup";
        private const string StepFour = "Add {drinkExtras}";

        private const string DrinkTypeReplaceToken = "{drinkType}";

        private static readonly int _drinkId = 1;

        [Test]
        public void GetRecipeStepsAsync_GivenDrinksRepositoryReturnsNull_DoesNotThrowException()
        {
            Assert.DoesNotThrowAsync(() => SystemUnderTest.GetRecipeStepsAsync(new int[0], _drinkId));
        }

        [Test]
        public async Task GetRecipeStepsAsync_GivenStepsIdsAreNull_ReturnsEmptyRecipeSteps()
        {
            var drink = new Drink
            {
                Id = _drinkId,
                Name = DrinkName,
            };

            AutoMock.Mock<IDrinksRepository>()
                .Setup(x => x.GetDrinkByIdAsync(_drinkId))
                .ReturnsAsync(drink);

            var result = await SystemUnderTest.GetRecipeStepsAsync(new int[0], _drinkId);

            result.ShouldNotBeNull();
            result.DrinkName.ShouldBe(DrinkName);
            result.RecipeSteps.Count.ShouldBe(0);
        }

        [Test]
        public async Task GetRecipeStepsAsync_GivenStepRepositoryReturnsNull_ReturnsEmptyRecipeSteps()
        {
            var drink = new Drink
            {
                Id = _drinkId,
                Name = DrinkName,
                RecipeStepsOrder = "1,2,3,4"
            };

            AutoMock.Mock<IDrinksRepository>()
                .Setup(x => x.GetDrinkByIdAsync(_drinkId))
                .ReturnsAsync(drink);

            var result = await SystemUnderTest.GetRecipeStepsAsync(new int[0], _drinkId);

            result.ShouldNotBeNull();
            result.DrinkName.ShouldBe(DrinkName);
            result.RecipeSteps.Count.ShouldBe(0);
        }

        [Test]
        public async Task GetRecipeStepsAsync_GivenNoExtras_ReturnsExpectedSteps()
        {
            var drink = new Drink
            {
                Id = _drinkId,
                Name = DrinkName,
                RecipeStepsOrder = "1,2,3,4",
                Type = DrinkTypes.Tea
            };

            var expectedStepList = new List<int> { 1, 2, 3, 4 };
            var recipeSteps = new List<RecipeStep>
            {
                new RecipeStep
                {
                    Id = 1,
                    StepName = StepOne
                },
                new RecipeStep
                {
                    Id = 2,
                    StepName = StepTwo
                },
                new RecipeStep
                {
                    Id = 3,
                    StepName = StepThree
                },
                new RecipeStep
                {
                    Id = 4,
                    StepName = StepFour
                }
            };

            AutoMock.Mock<IDrinksRepository>()
                .Setup(x => x.GetDrinkByIdAsync(_drinkId))
                .ReturnsAsync(drink);

            AutoMock.Mock<IRecipeStepsRepository>()
                .Setup(x => x.GetRecipeStepsByIdAsync(expectedStepList))
                .ReturnsAsync(recipeSteps);

            var result = await SystemUnderTest.GetRecipeStepsAsync(new int[0], _drinkId);

            result.ShouldNotBeNull();
            result.DrinkName.ShouldBe(DrinkName);
            result.RecipeSteps.Count.ShouldBe(3);
            result.RecipeSteps[0].ShouldBe(StepOne);
            result.RecipeSteps[1].ShouldBe(StepTwo);
            result.RecipeSteps[2].ShouldBe(StepThree.Replace(DrinkTypeReplaceToken, DrinkTypes.Tea.ToString()));
        }
    }
}
