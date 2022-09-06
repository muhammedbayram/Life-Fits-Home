using LifeFitsHome.Contexts;
using LifeFitsHome.Model.Entity;
using LifeFitsHome.Repositories.Base;
using LifeFitsHome.Repositories.Interfaces;

namespace LifeFitsHome.Repositories.Concrete
{
    public class UserRepository : EfEntityRepositoryBase<User, DbContextBase>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DbContextBase())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
