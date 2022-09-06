using LifeFitsHome.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeFitsHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : GenericBaseController<QRCode,IQRCodeService>
    {

        public QRCodeController(IQRCodeService qRCodeService) : base(qRCodeService)
        {
           
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAllQRCode());
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int qrCodeId)
        {
            return base.GetResponseByResultSuccess(base._service.GetQRCodeById(qrCodeId));
        }
        [HttpGet("getallbyuserid")]
        public IActionResult GetAllQRCodeByUser(int userId)
        {
            return base.GetResponseByResultSuccess(base._service.GetAllQRCodeByUser(userId));
        }

    }
}
