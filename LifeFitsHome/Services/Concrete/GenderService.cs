using LifeFitsHome.Model.Entity;
using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;
using IResult = LifeFitsHome.Utilities.Results.IResult;

namespace LifeFitsHome.Services.Concrete
{

    public class GenderService : IGenderService
    {
        private IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public IResult Add(Gender entity)
        {
            var FindedGender = _genderRepository.Get(e => e.Id == entity.Id);
            if (FindedGender == null)
            {
                _genderRepository.Add(entity);
                return new SuccessResult("Gender Added Successfuly");
            }
            return new ErrorResult("Gender Already Exist");
        }

        public IResult Delete(Gender entity)
        {
            var FindedGender=_genderRepository.Get(e=>e.Id ==entity.Id);
            if(FindedGender!=null){
                _genderRepository.Delete(entity);
                return new SuccessResult("Gender Delete Successfuly");
            }
            return new ErrorResult("Gender Not Found");
        }

        public IDataResult<List<Gender>> GetAll()
        {
            return new SuccessDataResult<List<Gender>>(_genderRepository.GetAll());
        }

        public IDataResult<List<Gender>> GetByGenderName(string genderName)
        {
            var FindedGenderName= _genderRepository.Get(e=>e.Name==genderName);
            if(FindedGenderName!=null){

                return new SuccessDataResult<List<Gender>>(_genderRepository.GetAll(e=>e.Name==genderName),"Gender Found");
            }
            return new ErrorDataResult<List<Gender>>("Gendername not Found");
        }

        public IDataResult<Gender> GetGenderById(int id)
        {
            var FindedGender=_genderRepository.Get(e=>e.Id ==id);
            
            if(FindedGender!=null){
                return new  SuccessDataResult<Gender>(FindedGender,"Gender Found");
            }
            return new ErrorDataResult<Gender>("Gender Not Found");
        }
        public IResult Update(Gender entity)
        {
            var FindedGender=_genderRepository.Get(e=>e.Id ==entity.Id);
            if(FindedGender!=null){
                _genderRepository.Update(entity);
               return new SuccessResult("Gender Update Successfuly");
            }
            return new ErrorResult("Gender Not Found");
        }
    }
}