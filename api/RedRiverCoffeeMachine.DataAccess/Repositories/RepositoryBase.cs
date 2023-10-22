using Microsoft.EntityFrameworkCore;
using RedRiverCoffeeMachine.Data.DataAccess;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace RedRiverCoffeeMachine.DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DrinksContext _context;

        public RepositoryBase(DrinksContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
