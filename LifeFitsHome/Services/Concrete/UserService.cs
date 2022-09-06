using LifeFitsHome.Model.Entity;
using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;
using IResult = LifeFitsHome.Utilities.Results.IResult;

namespace LifeFitsHome.Services.Concrete
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult Add(User user)
        {
            var FindedUser = _userRepository.Get(u => u.Email == user.Email);
            if (FindedUser == null)
            {
                _userRepository.Add(user);
                return new SuccessResult("Kullanıcı ekleme işlemi başarılı.");
            }
            return new ErrorResult("Eklenecek kullanıcı zaten mevcut.");
        }

        public IResult Delete(User user)
        {
            var FindedUser = _userRepository.Get(u => u.Email == user.Email);
            if (FindedUser != null)
            {
                _userRepository.Delete(user);
                return new SuccessResult("Kullanıcı silme işlemi başarılı.");
            }
            return new ErrorResult("Silinecek kullanıcı bulunamadı.");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userRepository.GetAll());
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userRepository.GetClaims(user));
        }

        public IDataResult<User> GetUserByEmail(string email)
        {
            var FindedUser = _userRepository.Get(u => u.Email == email);
            if (FindedUser != null)
            {
                return new SuccessDataResult<User>(FindedUser,"İstenilen kullanıcı getirildi.");
            }
            return new ErrorDataResult<User>("İstenilen kullanıcı bulunamadı.");
        }

        public IDataResult<User> GetUserById(int id)
        {
            return new SuccessDataResult<User>(_userRepository.Get(u => u.Id == id));
        }

        public IResult Update(User user)
        {
            var FindedUser = _userRepository.Get(u => u.Email == user.Email);
            if (FindedUser != null)
            {
                _userRepository.Update(user);
                return new SuccessResult("Kullanıcı güncelleme işlemi başarılı.");
            }
            return new ErrorResult("Güncellencek kullanıcı bulunamadı.");
        }
    }
}
