using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Models.Errors;

namespace TechShop.Models.Respones
{
    public class DataRespone<T>
    {
        public bool Status  { get; set; }
        public T Data  { get; set; }

        public MyErrorResponse Errors { get; set; }
    }
}
