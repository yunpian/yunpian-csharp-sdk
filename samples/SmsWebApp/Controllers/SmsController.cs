using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yunpian.Sdk;

namespace SmsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/sms/single
        [HttpPost("single")]
        public async Task<IActionResult> SendSinglelSms()
        {
            var factory = new ConnectionFactory(new YunpianOptions { ApiKey = "<your api key>"});
            var sms = factory.CreateSmsScope();
            await sms.SendSingleSmsAsync(new Yunpian.Sdk.Request.SingleSmsParameter { Text = "your templeate" });
            return Ok();
        }
    }
}
