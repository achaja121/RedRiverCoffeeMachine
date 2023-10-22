using RedRiverCoffeeMachine.Api.Services;
using RedRiverCoffeeMachine.Api.Services.Interfaces;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDrinksRepository, DrinksRepository>();
            services.AddScoped<IRecipeStepsRepository, RecipeStepsRepository>();
            services.AddScoped<IDrinkExtrasRepository, DrinkExtrasRepository>();
            services.AddTransient<IExtraRepository, ExtraRepository>();

            services.AddScoped<IDrinkService, DrinkService>();
            services.AddScoped<IDrinkExtrasService, DrinkExtrasService>();
            services.AddScoped<IRecipeStepsService, RecipeStepsService>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        } 
    }
}
