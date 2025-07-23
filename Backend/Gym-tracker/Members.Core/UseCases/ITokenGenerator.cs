using FluentResults;
using Members.API.Dtos;
using Members.Core.Domain;

namespace Members.Core.UseCases
{
    public interface ITokenGenerator
    {
        Result<AuthenticationTokensDto> GenerateAccessAndRefreshToken(User user);
        long GetUserIdFromToken(string jwtToken);

    }
}
