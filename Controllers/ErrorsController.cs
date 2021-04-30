using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Models.Errors;
using TechShop.Models.Respones;

namespace TechShop.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public DataRespone<string> Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var exception = context.Error;

            var path = context.Path;
            
            int code = 500;

            if (exception is MyNotFoundException)
            {
                code = 404;
            }
            else if (exception is MyBadRequestException)
            {
                code = 400;
            }
            else if (exception is MyUnauthorizedException)
            {
                code = 401;
            }

            Response.StatusCode = code;

            var errors = new MyErrorResponse(exception, code,path);

            return new DataRespone<string> { Status = false, Data = "", Errors = errors };
        }
    }
}
