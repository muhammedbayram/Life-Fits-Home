using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IVaccineTypeService : IServiceBase<VaccineType>
    {
        IDataResult<VaccineType> GetVaccineTypeById(int id);
        IDataResult<VaccineType> GetVaccineTypeByName(string email);
        IDataResult<List<VaccineType>> GetAll();
    }
}
