using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;
using IResult = LifeFitsHome.Utilities.Results.IResult;

namespace LifeFitsHome.Services.Concrete
{
        public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IResult Add(Address address)
        {
            var FindAddress=_addressRepository.Get(u=>u.Id==address.Id);
            if (FindAddress==null)
            {
                _addressRepository.Add(address);
                return new SuccessResult("address is added!");
            }
            return new ErrorResult("address is has been added already");
        }

        public IResult Delete(Address address)
        {
            var FindAddress=_addressRepository.Get(u=>u.Id==address.Id);
            if (FindAddress !=null)
            {
                _addressRepository.Delete(address);
                return new SuccessResult("address is deleted!");
            }
            return new ErrorResult("address is not found");
        }

        public IDataResult<Address> GetAddressByName(string name)
        {
            var FindAddress= _addressRepository.Get(u=>u.Name==name);
            if (FindAddress !=null)
            {
                return new SuccessDataResult<Address>(FindAddress,"The requested address has been brought");
            }
            return new ErrorDataResult<Address>("Address is not found");
        }

        public IDataResult<Address> GetAddressById(int id)
        {
            return new SuccessDataResult<Address>(_addressRepository.Get(u=>u.Id==id));
        }

        public IResult Update(Address address)
        {
            var FindAddress= _addressRepository.Get(u=>u.Name==address.Name);
            if (FindAddress !=null)
            {
                _addressRepository.Update(address);
                return new SuccessResult("address has been uptaded");
            }
            return new ErrorResult("address is not found");
        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressRepository.GetAll());
        }
    }
}