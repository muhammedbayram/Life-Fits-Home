using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        IDataResult <User> GetUserById (int id);
        IDataResult <User> GetUserByEmail (string email);
        IDataResult <List<User>> GetAll();
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
