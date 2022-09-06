using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IRegionService : IServiceBase<Region>
    {
        IDataResult <Region> GetRegionById (int id);
        IDataResult <Region> GetRegionByName (string Name);
        IDataResult <List<Region>> GetAll();
    }
}
