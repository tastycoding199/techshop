using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TechShop.Models.Errors
{
    public class MyBadRequestException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; } = HttpStatusCode.BadRequest;

        public MyBadRequestException(string msg) : base(msg)
        {

        }
    }
}
