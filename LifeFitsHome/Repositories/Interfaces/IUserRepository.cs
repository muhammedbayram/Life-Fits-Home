using LifeFitsHome.Model.Entity;
using LifeFitsHome.Repositories.Base;

namespace LifeFitsHome.Repositories.Interfaces
{
    public interface IUserRepository : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
