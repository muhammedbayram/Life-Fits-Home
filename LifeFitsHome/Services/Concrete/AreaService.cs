using LifeFitsHome.Model.Entity;
using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;
using IResult = LifeFitsHome.Utilities.Results.IResult;

namespace LifeFitsHome.Services.Concrete
{

    public class AreaService : IAreaService
    {
        private IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public IResult Add(Area entity)
        {
            var FindedArea=_areaRepository.Get(e=>e.Id ==entity.Id);
            if(FindedArea==null){
                _areaRepository.Add(entity);
                return new SuccessResult("Area Added Successfuly");
            }
            return new ErrorResult("Area Already Exist");
        }

        public IResult Delete(Area entity)
        {
            var FindedArea=_areaRepository.Get(e=>e.Id ==entity.Id);
            if(FindedArea!=null){
                _areaRepository.Delete(entity);
                return new SuccessResult("Area Delete Successfuly");
            }
            return new ErrorResult("Area Not Found");
        }

        public IDataResult<List<Area>> GetAll()
        {
            return new SuccessDataResult<List<Area>>(_areaRepository.GetAll());
        }

        public IDataResult<Area> GetAreaById(int id)
        {
            var FindedArea=_areaRepository.Get(e=>e.Id ==id);
            
            if(FindedArea!=null){
                return new  SuccessDataResult<Area>(FindedArea,"Area Found");
            }
            return new ErrorDataResult<Area>("Area Not Found");
        }

        public IDataResult<Area> GetAreaByType(int areaTypeId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Area>> GetBySafetyArea(bool isSafety)
        {
            return new SuccessDataResult <List<Area>>(_areaRepository.GetAll(e=>e.IsSafety==isSafety));
        }

        public IResult Update(Area entity)
        {
            var FindedArea=_areaRepository.Get(e=>e.Id ==entity.Id);
            if(FindedArea!=null){
                _areaRepository.Update(entity);
                return new SuccessResult("Area Update Successfuly");
            }
            return new ErrorResult("Area Not Found");
        }
    }
}