using Microsoft.EntityFrameworkCore;
using RedRiverCoffeeMachine.Data.Enums;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Models;

namespace RedRiverCoffeeMachine.DataAccess.Extensions
{
    internal static class ModelBuilderExtensions
    {
        public static void PopulateTables(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeStep>().HasData(GetRecipeSteps());
            modelBuilder.Entity<Drink>().HasData(GetDrinks());
            modelBuilder.Entity<Extra>().HasData(GetExtras());
            modelBuilder.Entity<DrinkExtra>().HasData(GetDrinkExtras());
        }

        private static DrinkExtra[] GetDrinkExtras()
        {
            return new DrinkExtra[]
            {
                new DrinkExtra 
                {
                    DrinkId = 1,
                    ExtraId = 1,
                },
                new DrinkExtra
                {
                    DrinkId = 1,
                    ExtraId = 2,
                },
                new DrinkExtra
                { 
                    DrinkId = 1,
                    ExtraId = 3
                },
                new DrinkExtra
                {
                    DrinkId = 2,
                    ExtraId = 2
                },
                new DrinkExtra
                {
                    DrinkId = 2,
                    ExtraId = 3
                },
                new DrinkExtra
                {
                    DrinkId = 3,
                    ExtraId = 2
                }
            };
        }

        private static Drink[] GetDrinks()
        {
            return new Drink[]
            {
                new Drink
                {
                    Id= 1,
                    Name = "Lemon Tea",
                    Type = DrinkTypes.Tea,
                    RecipeStepsOrder = "1,2,3,4"
                },
                new Drink
                {
                    Id= 2,
                    Name = "Coffee",
                    Type = DrinkTypes.Coffee,
                    RecipeStepsOrder = "1,5,3,4"
                },
                new Drink
                {
                    Id= 3,
                    Name = "Chocolate",
                    Type = DrinkTypes.Chocolate,
                    RecipeStepsOrder = "1,6,3"
                }
            };
        }

        private static Extra[] GetExtras()
        {
            return new Extra[]
            {
                new Extra
                {
                    Id= 1,
                    Name = "Lemon"
                },
                new Extra
                {
                    Id= 2,
                    Name = "Sugar"
                },
                new Extra
                {
                    Id= 3,
                    Name = "Milk"
                }
            };
        }

        private static RecipeStep[] GetRecipeSteps()
        {
            return new RecipeStep[]
            {
                new RecipeStep
                {
                    Id= 1,
                    StepName = "Boil some water"
                },
                new RecipeStep
                {
                    Id= 2,
                    StepName = "Steep the water in the tea"
                },
                new RecipeStep
                {
                    Id= 3,
                    StepName = "Pour {drinkType} in the cup"
                },
                new RecipeStep
                {
                    Id= 4,
                    StepName = "Add {drinkExtras}"
                },
                new RecipeStep
                {
                    Id= 5,
                    StepName = "Brew the coffee grounds"
                },
                new RecipeStep
                {
                    Id= 6,
                    StepName = "Add drinking chocolate powder to the water"
                }
            };
        }
    }
}
