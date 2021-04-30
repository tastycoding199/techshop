using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TechShop.Models.Errors
{
    public class MyUnauthorizedException:Exception
    {
        public HttpStatusCode HttpStatusCode { get;private set; } = HttpStatusCode.Unauthorized;

        public MyUnauthorizedException(string msg) : base(msg)
        {

        }
    }
}
