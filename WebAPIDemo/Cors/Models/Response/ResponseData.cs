using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cors.Models.Response
{
    public class ResponseData
    {
        public int Code { get; set; } = 200;
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}