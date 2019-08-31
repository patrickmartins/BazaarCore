using System;
using System.Collections.Generic;
using System.Text;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Jwt
{
    public class JwtConfiguration
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenLifeTime { get; set; }
    }
}
