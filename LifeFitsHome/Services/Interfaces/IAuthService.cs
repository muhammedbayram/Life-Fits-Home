using LifeFitsHome.Model.DTOs;
using LifeFitsHome.Model.Entity;
using LifeFitsHome.Utilities.Results;
using LifeFitsHome.Utilities.Security.JWT;
using IResult = LifeFitsHome.Utilities.Results.IResult;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
