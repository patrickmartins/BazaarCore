using System;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Jwt
{
    public class JwtToken
    {
        public string AccessToken { get; set; }
        public DateTime ExpireIn { get; set; }
    }
}
