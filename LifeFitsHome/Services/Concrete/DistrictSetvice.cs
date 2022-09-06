using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Concrete
{
    public class DistrictService:IDistrictService
    {
        private IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public Utilities.Results.IResult Add(District district)
        {
            var FindedDistrict = _districtRepository.Get(u => u.Name == district.Name);
            if (FindedDistrict == null)
            {
                _districtRepository.Add(district);
                return new SuccessResult("District is added");
            }
            return new ErrorResult("District is has been added already.");
        }

        public Utilities.Results.IResult Delete(District district)
        {
             var FindedDistrict = _districtRepository.Get(u => u.Name == district.Name);
            if (FindedDistrict != null)
            {
                _districtRepository.Delete(district);
                return new SuccessResult("District is deleted.");
            }
            return new ErrorResult("District is not found.");
        }

        public IDataResult<List<District>> GetAll()
        {
            return new SuccessDataResult<List<District>>(_districtRepository.GetAll());
        }

        public IDataResult<District> GetDistrictById(int id)
        {
            return new SuccessDataResult<District>(_districtRepository.Get(u => u.Id == id));
        }

        public IDataResult<District> GetDistrictByName(string Name)
        {
            var FindedDistrict = _districtRepository.Get(u => u.Name == Name);
            if (FindedDistrict != null)
            {
                return new SuccessDataResult<District>(FindedDistrict,"The requested District has been brought.");
            }
            return new ErrorDataResult<District>("District is not found.");
        }

        public Utilities.Results.IResult Update(District district)
        {
            var FindedDistrict = _districtRepository.Get(u => u.Name == district.Name);
            if (FindedDistrict != null)
            {
                _districtRepository.Update(district);
                return new SuccessResult("District has been uptaded.");
            }
            return new ErrorResult("District is not found");
        }
    }
}