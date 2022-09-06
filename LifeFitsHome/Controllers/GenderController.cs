using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GenderController:GenericBaseController<Gender,IGenderService>
    {
        public GenderController(IGenderService genderService):base(genderService)
        {

        }
       

        [HttpGet("genderbyid")]
        public IActionResult GetGenderById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetGenderById(id));
        }
        [HttpGet("getbygendername")]
        public IActionResult GetByGenderName(string genderName)
        {
            return base.GetResponseByResultSuccess(base._service.GetByGenderName(genderName));
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }

    }

}