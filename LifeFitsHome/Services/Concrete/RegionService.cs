using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Concrete
{
    public class RegionService:IRegionService
    {
        private IRegionRepository _regionRepository;
        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public Utilities.Results.IResult Add(Region region)
        {
            var FindedRegion = _regionRepository.Get(u => u.Name == region.Name);
            if (FindedRegion == null)
            {
                _regionRepository.Add(region);
                return new SuccessResult("region is added");
            }
            return new ErrorResult("region is has been added already.");
        }

        public Utilities.Results.IResult Delete(Region region)
        {
            var FindedRegion = _regionRepository.Get(u => u.Name == region.Name);
            if (FindedRegion != null)
            {
                _regionRepository.Delete(region);
                return new SuccessResult("region is deleted.");
            }
            return new ErrorResult("region is not found.");
        }

        public IDataResult<List<Region>> GetAll()
        {
            return new SuccessDataResult<List<Region>>(_regionRepository.GetAll());
        }

        public IDataResult<Region> GetRegionById(int id)
        {
            return new SuccessDataResult<Region>(_regionRepository.Get(u => u.Id == id));
        }

        public IDataResult<Region> GetRegionByName(string Name)
        {
            var FindedRegion = _regionRepository.Get(u => u.Name == Name);
            if (FindedRegion != null)
            {
                return new SuccessDataResult<Region>(FindedRegion,"The requested region has been brought.");
            }
            return new ErrorDataResult<Region>("region is not found.");
        }

        public Utilities.Results.IResult Update(Region region)
        {
            var FindedRegion = _regionRepository.Get(u => u.Name == region.Name);
            if (FindedRegion != null)
            {
                _regionRepository.Update(region);
                return new SuccessResult("region has been uptaded.");
            }
            return new ErrorResult("region is not found");
        }
    }
}