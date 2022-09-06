using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IGenderService : IServiceBase<Gender>
    {
        IDataResult <Gender> GetGenderById (int id);
        IDataResult <List<Gender>> GetByGenderName(string genderName);
        IDataResult <List<Gender>> GetAll();
    }
}