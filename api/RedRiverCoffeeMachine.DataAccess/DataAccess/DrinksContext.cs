using Microsoft.EntityFrameworkCore;
using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.Data.DataAccess
{
    public class DrinksContext : DbContext
    {
        public DrinksContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkExtra> DrinkExtras { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
    }
}
