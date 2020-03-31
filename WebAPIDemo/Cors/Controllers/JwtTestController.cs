using Cors.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cors.Controllers
{
    public class JwtTestController : ApiController
    {
        // jwt

        public bool Login()
        {
            var dictionary = new Dictionary<string, object> {
                 { "UserId",123},
            };
            JwtTool.Encode(dictionary, JwtTool.secret);
            return true;
        }
        public string GetUserInfo()
        {
            var username = JwtTool.ValideLogined(ControllerContext.Request.Headers);
            return "用户名" + username;
        }
    }
}
