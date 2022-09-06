using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Concrete
{
    public class CityService:ICityService
    {
        private ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public Utilities.Results.IResult Add(City city)
        {
            var FindedCity = _cityRepository.Get(u => u.Name == city.Name);
            if (FindedCity == null)
            {
                _cityRepository.Add(city);
                return new SuccessResult("City is added");
            }
            return new ErrorResult("city is has been added already.");
        }

        public Utilities.Results.IResult Delete(City city)
        {
            var FindedCity = _cityRepository.Get(u => u.Name == city.Name);
            if (FindedCity != null)
            {
                _cityRepository.Delete(city);
                return new SuccessResult("city is deleted.");
            }
            return new ErrorResult("City is not found.");
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityRepository.GetAll());
        }

        public IDataResult<City> GetCityByName(string Name)
        {
             var FindedCity = _cityRepository.Get(u => u.Name == Name);
            if (FindedCity != null)
            {
                return new SuccessDataResult<City>(FindedCity,"The requested city has been brought.");
            }
            return new ErrorDataResult<City>("city is not found.");
        }

        public IDataResult<City> GetCityById(int id)
        {
            return new SuccessDataResult<City>(_cityRepository.Get(u => u.Id == id));
        }

        public Utilities.Results.IResult Update(City city)
        {
           var FindedCity = _cityRepository.Get(u => u.Name == city.Name);
            if (FindedCity != null)
            {
                _cityRepository.Update(city);
                return new SuccessResult("City has been uptaded.");
            }
            return new ErrorResult("City is not found");
        }
    }
}