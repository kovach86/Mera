using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TextInfoWebApi.Controllers
{
    [RoutePrefix("status")]
    public class HealthCheckController : ApiController
    {
        [HttpGet, Route("check")]
        public IHttpActionResult CheckStatus()
        {
            return Ok();
        }
    }
}
