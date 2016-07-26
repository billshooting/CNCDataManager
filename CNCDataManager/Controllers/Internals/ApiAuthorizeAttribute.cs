using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;

namespace CNCDataManager.Controllers.Internals
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException(nameof(actionContext));
            }

            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}