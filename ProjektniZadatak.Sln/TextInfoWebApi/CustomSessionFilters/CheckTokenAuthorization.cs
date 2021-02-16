using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using CustomErrorLogger;

namespace TextInfoWebApi.CustomSessionFilters
{
    public class CheckTokenAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var tokenParam = actionExecutedContext.Request.Headers.Authorization.Parameter;
            if (tokenParam == null)
            {
                CustomNLogger.LogException("Token authorization failed");
            }
        }
    }
}