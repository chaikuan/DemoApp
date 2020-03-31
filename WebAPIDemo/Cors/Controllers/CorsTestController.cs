using Cors.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cors.Controllers
{
    public class CorsTestController : ApiController
    {
        [EnableCors("*","*","*")]
        public string Get()
        {
            return "跨域测试";
        }
    }
}
