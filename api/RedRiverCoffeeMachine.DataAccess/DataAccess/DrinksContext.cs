using Microsoft.EntityFrameworkCore;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Extensions;
using RedRiverCoffeeMachine.DataAccess.Models;

namespace RedRiverCoffeeMachine.Data.DataAccess
{
    public class DrinksContext : DbContext
    {
        public DrinksContext(DbContextOptions<DrinksContext> options) : base(options) 
        { 
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrinkExtra>().HasKey(de => new { de.DrinkId, de.ExtraId });

            modelBuilder.PopulateTables();

            base.OnModelCreating(modelBuilder);
        }
    }
}
