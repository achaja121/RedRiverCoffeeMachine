using RedRiverCoffeeMachine.Data.DataAccess;
using RedRiverCoffeeMachine.Data.Models;
using RedRiverCoffeeMachine.DataAccess.Repositories.Interfaces;

namespace RedRiverCoffeeMachine.DataAccess.Repositories
{
    public class ExtraRepository : RepositoryBase<Extra>, IExtraRepository
    {
        public ExtraRepository(DrinksContext context) : base(context)
        {
        }

        public async Task<Extra?> AddExtraAsync(Extra extra)
        {
            var isSuccess = await AddAsync(extra);

            return isSuccess ? await FirstOrDefaultAsync(x => x.Name == extra.Name) : default;
        }
    }
}
