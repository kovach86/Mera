using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace TextInfoWebApi.Controllers
{
    [RoutePrefix("token")]
    public class GetTokenController : ApiController
    {
        [HttpGet, Route("get-token")]
        public string GetToken()
        {
            string token = System.Configuration.ConfigurationManager.AppSettings["token"];
            return token;
        }

        [HttpGet, Route("validate")]
        public IHttpActionResult ValidateToken(HttpActionContext actionContext)
        {
             
            var token_value = Request.Headers.Authorization.Parameter;
            if (string.IsNullOrEmpty(token_value))
                return Ok("Odbij");

            return Ok();
        }
    }
}
