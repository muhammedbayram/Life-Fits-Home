using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IAreaService : IServiceBase<Area>
    {
        IDataResult <Area> GetAreaById (int id);
        IDataResult <Area> GetAreaByType (int areaTypeId);
        IDataResult <List<Area>> GetBySafetyArea (bool isSafety);
        IDataResult <List<Area>> GetAll();
    }
}
