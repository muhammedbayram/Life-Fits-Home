using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IVaccineService : IServiceBase<Vaccine>
    {
        IDataResult<Vaccine> GetVaccineById(int id);
        IDataResult<Vaccine> GetVaccineByName(string email);
        IDataResult<Vaccine> GetVaccineByVaccineTypeId(int vaccineTypeId);
        IDataResult<List<Vaccine>> GetAll();
    }
}
