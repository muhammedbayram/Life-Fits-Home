using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericBaseController<User, IUserService>
    {
        public UserController(IUserService userService) : base(userService)
        {
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }
        [HttpGet("getclaims")]
        public IActionResult GetClaims(User user)
        {
            return base.GetResponseByResultSuccess(base._service.GetClaims(user));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetUserById(id));
        }
        [HttpGet("getbyemail")]
        public IActionResult GetByEmail(string email)
        {
            return base.GetResponseByResultSuccess(base._service.GetUserByEmail(email));
        }
    }
}
