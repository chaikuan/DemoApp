using Cors.Models.Auth;
using Cors.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Cors.Filters
{
    public class MyAuthAttribute : Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple { get; }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            IEnumerable<string> headers;
            if(actionContext.Request.Headers.TryGetValues("token",out headers))
            {
                var loginName = JwtTool.Decode(JwtTool.secret,headers.First())["LoginName"].ToString();
                var id = (int)JwtTool.Decode(JwtTool.secret, headers.First())["Id"];
                (actionContext.ControllerContext.Controller as ApiController).User = new ApplicationUser(id,loginName);
                return await continuation();
            }
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}