using RedRiverCoffeeMachine.Data.Models;

namespace RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces
{
    public interface IExtraRepository : IRepositoryBase<Extra>
    {
        Task<Extra?> AddExtraAsync(Extra extra);
    }
}
