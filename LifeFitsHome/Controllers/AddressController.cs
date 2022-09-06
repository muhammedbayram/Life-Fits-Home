using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AddressController:GenericBaseController<Address,IAddressService>
    {
        public AddressController(IAddressService addressService):base(addressService)
        {

        }
        [HttpGet("addressbyid")]
        public IActionResult GetAddressById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetAddressById(id));
        }
        [HttpGet("addressbyname")]
        public IActionResult GetAddressByName(string name)
        {
            return base.GetResponseByResultSuccess(base._service.GetAddressByName(name));
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }

    }

}