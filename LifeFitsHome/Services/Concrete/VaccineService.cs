using LifeFitsHome.Model.Entity;
using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;
using IResult = LifeFitsHome.Utilities.Results.IResult;

namespace LifeFitsHome.Services.Concrete
{
    public class VaccineService : IVaccineService
    {
        private IVaccineRepository _vaccineRepository;

        public VaccineService(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public IResult Add(Vaccine vaccine)
        {
            Vaccine existingVaccine = _vaccineRepository.Get(v => v.Name == vaccine.Name);
            if (existingVaccine != null)
            {
                return new ErrorResult("This vaccine has already exist");
            }
            _vaccineRepository.Add(vaccine);
            return new SuccessResult("Vaccine added successfull");
        }

        public IResult Delete(Vaccine vaccine)
        {
            Vaccine existingVaccine = _vaccineRepository.Get(v => v.Name == vaccine.Name);
            if (existingVaccine == null)
            {
                return new ErrorResult("The vaccine attempted to delete does not exist");
            }
            _vaccineRepository.Delete(vaccine);
            return new SuccessResult("Vaccine deleted successfull");
        }

        public IDataResult<List<Vaccine>> GetAll()
        {
            return new SuccessDataResult<List<Vaccine>>(_vaccineRepository.GetAll());
        }

        public IDataResult<Vaccine> GetVaccineById(int id)
        {
            Vaccine existingVaccine = _vaccineRepository.Get(v => v.Id == id);
            if (existingVaccine == null)
            {
                return new ErrorDataResult<Vaccine>("Vaccine not found");
            }
            return new SuccessDataResult<Vaccine>(existingVaccine, "Requested vaccine found");
        }

        public IDataResult<Vaccine> GetVaccineByName(string name)
        {
            Vaccine existingVaccine = _vaccineRepository.Get(v => v.Name == name);
            if (existingVaccine == null)
            {
                return new ErrorDataResult<Vaccine>("Vaccine not found");
            }
            return new SuccessDataResult<Vaccine>(existingVaccine, "Requested vaccine found");
        }

        public IDataResult<Vaccine> GetVaccineByVaccineTypeId(int vaccineTypeId)
        {
            Vaccine existingVaccine = _vaccineRepository.Get(v => v.VaccineTypeId == vaccineTypeId);
            if (existingVaccine == null)
            {
                return new ErrorDataResult<Vaccine>("Vaccine not found");
            }
            return new SuccessDataResult<Vaccine>(existingVaccine, "Requested vaccine found");
        }

        public IResult Update(Vaccine vaccine)
        {
            Vaccine existingVaccine = _vaccineRepository.Get(v => v.Name == vaccine.Name);
            if (existingVaccine == null)
            {
                return new ErrorResult("The vaccine attempted to update does not exist");
            }
            _vaccineRepository.Update(vaccine);
            return new SuccessResult("Vaccine updated successfull");
        }
    }

}

