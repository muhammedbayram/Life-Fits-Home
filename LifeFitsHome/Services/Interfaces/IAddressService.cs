using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IAddressService : IServiceBase<Address>
    {
        IDataResult <Address> GetAddressById (int id);
        IDataResult <Address> GetAddressByName (string name);
        IDataResult <List<Address>> GetAll();
    }
}
