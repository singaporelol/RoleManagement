using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RoleManagementAPI
{
    public class BaseAuthenticationAttribute: AuthorizationFilterAttribute 
    {
        public bool IsCheck { get; set; }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (IsCheck)
            {
                var test=actionContext.Request.Headers.GetCookies("Authorization1").FirstOrDefault();
                if (actionContext.Request.Headers.Authorization == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {

                }

            }
        }
    }
}