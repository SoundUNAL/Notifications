using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationsMS.Models;
using NotificationsMS.Services;

namespace NotificationsMS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetDistributionNot : ControllerBase
    {

        public DistributionNotiService _distributionNotiService;

        public GetDistributionNot(DistributionNotiService distributionNotiService)
        {
            _distributionNotiService = distributionNotiService;
        }



        [HttpGet]
        public ActionResult<List<DistributionNotification>> Get()
        {
            return _distributionNotiService.Get();
        }
        [HttpPost("PostDistribution")]
        public ActionResult<DistributionNotification> Post(DistributionNotification noti)
        {
            _distributionNotiService.Create(noti);
            return Ok(noti);
        }
        [HttpPut("UpdateDistribution")]
        public ActionResult Update(DistributionNotification infoNotification)
        {

            _distributionNotiService.Update(infoNotification.Id, infoNotification);
            return Ok();
        }
        [HttpDelete("DeleteDistribution")]
        public ActionResult Delete(string id)
        {
            _distributionNotiService.Delete(id);
            return Ok();
        }
    }
}
