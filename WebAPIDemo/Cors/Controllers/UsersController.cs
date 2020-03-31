using Cors.Filters;
using Cors.Models;
using Cors.Models.Auth;
using Cors.Models.Response;
using Cors.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cors.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [Route("login")]
        public IHttpActionResult Login(UserLoginViewModel userLoginViewModel)
        {
            var payload = new Dictionary<string, object>
            {
                { "userId","123"},
                { "LoginName",userLoginViewModel.LoginName}
            };
            return Ok(new ResponseData()
            {
                Data = JwtTool.Encode(payload, JwtTool.secret)
            });
        }
        [MyAuth]
        [HttpGet]
        [Route("GetUserInfo")]
        public IHttpActionResult GetUserInfo()
        {
            UserIdentity userIdentity = ((UserIdentity)User.Identity);
            return Ok(new ResponseData() { Data = new { Id = userIdentity.Id, Name = userIdentity.Name } });
        }
    }
}
