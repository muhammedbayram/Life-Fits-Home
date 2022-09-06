using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CityController : GenericBaseController<City, ICityService>
    {
        public CityController(ICityService cityService) : base(cityService)
        {
        }
        [HttpGet("citybyid")]
        public IActionResult GetCityById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetCityById(id));
        }
        [HttpGet("citybyname")]
        public IActionResult GetCityByName(string name)
        {
            return base.GetResponseByResultSuccess(base._service.GetCityByName(name));
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }
    }
}