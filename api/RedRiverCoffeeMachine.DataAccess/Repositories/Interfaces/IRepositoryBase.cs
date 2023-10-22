using System.Linq.Expressions;

namespace RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<bool> AddAsync(T entity);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        Task<bool> AddRangeAsync(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetAllAsync();

        Task<bool> UpdateAsync(T entity);

        Task<bool> UpdateRangeAsync(IEnumerable<T> entities);
    }
}
