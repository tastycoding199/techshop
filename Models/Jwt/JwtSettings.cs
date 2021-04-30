using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Models.Jwt
{
    public class JwtSettings
    {
        public string Secret { get; set;}

        private SymmetricSecurityKey Skey ;

        public SymmetricSecurityKey getSkey()
        {
            Skey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
            return Skey;
        }

    }
}
