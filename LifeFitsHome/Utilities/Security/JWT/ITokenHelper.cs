using LifeFitsHome.Model.Entity;

namespace LifeFitsHome.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
