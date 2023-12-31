﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RedRiverCoffeeMachine.Data.DataAccess;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace RedRiverCoffeeMachine.DataAccess.Repositories
{
    public class DrinkExtrasRepository : RepositoryBase<DrinkExtra>, IDrinkExtrasRepository
    {
        public DrinkExtrasRepository(DrinksContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DrinkExtra>> GetDrinkExtrasByDrinkIdAsync(int drinkId)
        {
            return await _context.Set<DrinkExtra>()
                .Include(eOne => eOne.Extra)
                .Where(x => x.DrinkId == drinkId).ToListAsync();
        }

        public async Task<IEnumerable<DrinkExtra>> GetDrinkExtrasByExtraIdAsync(int drinkId, int[] extraIds)
        {
            return await _context.Set<DrinkExtra>()
                .Include(eOne => eOne.Extra)
                .Where(x => x.DrinkId == drinkId && extraIds.Any(id => x.ExtraId == id)).ToListAsync();
        }
    }
}
