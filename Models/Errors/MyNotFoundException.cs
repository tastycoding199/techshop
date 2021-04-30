using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TechShop.Models.Errors
{
    public class MyNotFoundException:Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; } = HttpStatusCode.NotFound;

        public MyNotFoundException(string msg) : base(msg)
        {

        }
    }
}
