using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DistrictController : GenericBaseController<District, IDistrictService>
    {
        public DistrictController(IDistrictService districtService) : base(districtService)
        {
        }
        [HttpGet("districtbyid")]
        public IActionResult GetDistrictById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetDistrictById(id));
        }
        [HttpGet("districtbyname")]
        public IActionResult GetDistrictByName(string name)
        {
            return base.GetResponseByResultSuccess(base._service.GetDistrictByName(name));
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }
    }
}