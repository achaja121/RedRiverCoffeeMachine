﻿using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.DataAccess.Repositories
{
    public class DrinkExtrasRepository : IDrinkExtrasRepository
    {
        public Task<Extra> AddDrinkExtraAsync(Extra drinkExtra)
        {
            throw new NotImplementedException();
        }
    }
}
