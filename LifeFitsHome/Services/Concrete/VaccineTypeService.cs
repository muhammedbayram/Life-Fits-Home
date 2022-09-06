using LifeFitsHome.Model.Entity;
using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;
using IResult = LifeFitsHome.Utilities.Results.IResult;

namespace LifeFitsHome.Services.Concrete
{
    public class VaccineTypeService : IVaccineTypeService
    {
        private IVaccineTypeRepository _vaccineTypeRepository;

        public VaccineTypeService(IVaccineTypeRepository vaccineTypeRepository)
        {
            _vaccineTypeRepository = vaccineTypeRepository;
        }

        public IResult Add(VaccineType vaccineType)
        {
            VaccineType existingType = _vaccineTypeRepository.Get(t => t.Name == vaccineType.Name);
            if(existingType != null){
                return new ErrorResult("This vaccine type has already exist");
            }
            _vaccineTypeRepository.Add(vaccineType);
            return new SuccessResult("Vaccine type added successfull");
        }

        public IResult Delete(VaccineType vaccineType)
        {
            VaccineType existingType = _vaccineTypeRepository.Get(t => t.Name == vaccineType.Name);
            if(existingType == null){
                return new ErrorResult("The vaccine attempted to delete does not exist");
            }
            _vaccineTypeRepository.Delete(vaccineType);
            return new SuccessResult("Vaccine type deleted successfull");
        }

        public IDataResult<List<VaccineType>> GetAll()
        {
            return new SuccessDataResult<List<VaccineType>>(_vaccineTypeRepository.GetAll());
        }

        public IDataResult<VaccineType> GetVaccineTypeById(int id)
        {
            VaccineType existingType = _vaccineTypeRepository.Get(v => v.Id == id);
            if (existingType == null)
            {
                return new ErrorDataResult<VaccineType>("Vaccine type not found");
            }
            return new SuccessDataResult<VaccineType>(existingType, "Requested vaccine type found");
        }

        public IDataResult<VaccineType> GetVaccineTypeByName(string name)
        {
            VaccineType existingType = _vaccineTypeRepository.Get(v => v.Name == name);
            if (existingType == null)
            {
                return new ErrorDataResult<VaccineType>("Vaccine type not found");
            }
            return new SuccessDataResult<VaccineType>(existingType, "Requested vaccine type found");
        }

        public IResult Update(VaccineType vaccineType)
        {
            VaccineType existingType = _vaccineTypeRepository.Get(v => v.Name == vaccineType.Name);
            if (existingType == null)
            {
                return new ErrorResult("The vaccine type attempted to update does not exist");
            }
            _vaccineTypeRepository.Update(vaccineType);
            return new SuccessResult("Vaccine type updated successfull");
        }
    }
}

