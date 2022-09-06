using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AreaController:GenericBaseController<Area,IAreaService>
    {
        public AreaController(IAreaService areaservice):base(areaservice)
        {

        }
        [HttpGet("getbysafetyarea")]
        public IActionResult GetBySafetyArea(bool isSafety){
            return base.GetResponseByResultSuccess(base._service.GetBySafetyArea(isSafety));
        }


        [HttpGet("areabyid")]
        public IActionResult GetAreaById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetAreaById(id));
        }
        [HttpGet("areabytype")]
        public IActionResult GetAreaByType(int areaTypeId)
        {
            return base.GetResponseByResultSuccess(base._service.GetAreaByType(areaTypeId));
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }

    }

}