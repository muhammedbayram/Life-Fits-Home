using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : GenericBaseController<Vaccine, IVaccineService>
    {
        public VaccineController(IVaccineService vaccineService) : base(vaccineService)
        {
        }

        [HttpGet("getbyname")]
        public IActionResult GetVaccineByName(string name)
        {
            return base.GetResponseByResultSuccess(base._service.GetVaccineByName(name));
        }
        [HttpGet("getbyid")]
        public IActionResult GetVaccineById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetVaccineById(id));
        }
        [HttpGet("getbyvaccinetypeid")]
        public IActionResult GetVaccineByVaccineTypeId(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetVaccineByVaccineTypeId(id));
        }
       
    }
}
