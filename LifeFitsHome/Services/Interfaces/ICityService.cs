using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface ICityService : IServiceBase<City>
    {
        IDataResult <City> GetCityById (int id);
        IDataResult <City> GetCityByName (string Name);
        IDataResult <List<City>> GetAll();
    }
}
