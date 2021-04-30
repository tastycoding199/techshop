using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Models.Errors
{
    public class MyErrorResponse
    {
        public int code { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }

        public string Path { get; set; }

        public MyErrorResponse(Exception ex, int code,string path)
        {
            this.code = code;
            Type = ex.GetType().Name;
            Message = ex.Message;
            Path = path;

        }
    }
}
