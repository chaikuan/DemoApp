using Cors.Models;
using Cors.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cors.Controllers
{
    public class ValidTestController : ApiController
    {
        public IHttpActionResult ValidTest(Student student)
        {
            if (ModelState.IsValid)
            {
                return Ok(new ResponseData());
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
