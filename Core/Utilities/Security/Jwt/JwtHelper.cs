using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        IConfiguration Configuration { get; }
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateAccessToken(User user,List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddHours(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signigCredentialsKey = SigningCredentialsKeyHelper.CreateSigningCredentialsKey(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions,user,operationClaims,signigCredentialsKey);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, List<OperationClaim> operationClaims, SigningCredentials signigCredentialsKey)
        {
            var jwt = new JwtSecurityToken(

                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signigCredentialsKey,
                claims: SetClaims(user,operationClaims)
                );
            return jwt;
        }

        private List<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(r=>r.Name).ToArray());
            return claims;            
        }
    }
}
