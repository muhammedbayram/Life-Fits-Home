using LifeFitsHome.Model.Entity;
using LifeFitsHome.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IResult = LifeFitsHome.Utilities.Results.IResult;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericBaseController<T, TService> : ControllerBase
        where TService : IServiceBase<T>
        where T : class, IEntity, new()
    {
        protected TService _service;

        public GenericBaseController(TService tService) => this._service = tService;

        [HttpPost("add")]
        public virtual IActionResult Add(T entity) => GetResponseByResultSuccess(_service.Add(entity));

        [HttpPut("update")]
        public virtual IActionResult Update(T entity) => GetResponseByResultSuccess(_service.Update(entity));

        [HttpDelete("delete")]
        public virtual IActionResult Delete(T entity) => GetResponseByResultSuccess(_service.Delete(entity));

        protected IActionResult GetResponseByResultSuccess(IResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
