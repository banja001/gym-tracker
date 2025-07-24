using FluentResults;
using Members.API.Dtos;
using Members.Core.Domain;
using Members.Core.UseCases;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Members.Infrastructure.Authentification
{
    public class JwtGenerator : ITokenGenerator
    {
        private readonly string _key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "gym_tracker_best_secret_key_12345";
        private readonly string _issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "gym_tracker";
        private readonly string _audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "gym_tracker-front.com";

        public Result<AuthenticationTokensDto> GenerateAccessToken(User user)
        {
            var authenticationResponse = new AuthenticationTokensDto();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("id", user.Id.ToString()),
                new("username", user.Username),
                new("firstname", user.FirstName),
                new("lastname", user.LastName)
            };

            var jwt = CreateToken(claims, 60);
            authenticationResponse.Id = user.Id;
            authenticationResponse.AccessToken = jwt;
            return authenticationResponse;
        }
        private string CreateToken(IEnumerable<Claim> claims, double expirationTimeInMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(expirationTimeInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public long GetUserIdFromToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jsonToken?.Payload != null && jsonToken.Payload.TryGetValue("id", out var userId))
            {
                if (userId is string userIdString && long.TryParse(userIdString, out var userIdLong))
                {
                    return userIdLong;
                }
            }

            return 0;
        }
    }
}
