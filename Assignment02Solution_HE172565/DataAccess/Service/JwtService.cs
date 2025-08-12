using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.DTO.ApplicationUser;
using BusinessObject.ModelsConfig;
using Microsoft.Extensions.Options;

namespace DataAccess.Service
{
    public interface IJwtService
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        void SetTokensInsideCookie(UserContentDTO user, HttpContext context);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }

    public class JwtService : IJwtService
    {
        private readonly JwtConfig _jwtConfig;

        public JwtService(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }

        public void SetTokensInsideCookie(UserContentDTO user, HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
