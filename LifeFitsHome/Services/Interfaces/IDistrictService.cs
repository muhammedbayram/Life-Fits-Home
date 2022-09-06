using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IDistrictService : IServiceBase<District>
    {
        IDataResult <District> GetDistrictById (int id);
        IDataResult <District> GetDistrictByName (string Name);
        IDataResult <List<District>> GetAll();
    }
}
