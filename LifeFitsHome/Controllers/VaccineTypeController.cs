using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineTypeController : GenericBaseController<VaccineType, IVaccineTypeService>
    {
        public VaccineTypeController(IVaccineTypeService vaccineTypeService) : base(vaccineTypeService)
        {
        }

        [HttpGet("getbyname")]
        public IActionResult GetVaccineTypeByName(string name)
        {
            return base.GetResponseByResultSuccess(base._service.GetVaccineTypeByName(name));
        }
        [HttpGet("getbyid")]
        public IActionResult GetVaccineTypeById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetVaccineTypeById(id));
        }
       
    }
}
