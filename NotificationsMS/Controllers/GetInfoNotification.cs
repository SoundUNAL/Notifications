using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NotificationsMS.Models;
using NotificationsMS.Services;

namespace NotificationsMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetInfoNotification : ControllerBase
    {
        public NotificationService _notificationService;

        public GetInfoNotification(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }



        [HttpGet]
        public ActionResult<List<InfoNotification>> Get()
        {
            return _notificationService.Get();
        }
        [HttpPost("PostNotification")]
        public ActionResult<InfoNotification> Post(InfoNotification noti) {
            _notificationService.Create(noti);
            return Ok(noti);
        }
        [HttpPut("UpdateNotification")]
        public ActionResult Update(InfoNotification infoNotification) {

            _notificationService.Update(infoNotification.Id, infoNotification);
            return Ok();
        }
        [HttpDelete("DeleteNotification")]
        public ActionResult Delete(string id)
        {
            _notificationService.Delete(id);
            return Ok();
        }


    }
}
