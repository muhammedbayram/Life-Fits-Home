using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegionController : GenericBaseController<Region, IRegionService>
    {
        public RegionController(IRegionService regionService) : base(regionService)
        {
        }
        [HttpGet("regionybyid")]
        public IActionResult GetRegionById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetRegionById(id));
        }
        [HttpGet("regionbyname")]
        public IActionResult GetRegionByName(string name)
        {
            return base.GetResponseByResultSuccess(base._service.GetRegionByName(name));
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }
    }
}