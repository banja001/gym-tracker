using FluentResults;
using Members.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.API.Public
{
    public interface IAuthenticationService
    {
        Result<AuthenticationTokensDto> Login(CredentialsDto credentials);
        Result<RegisteredUserDto> Register(AccountRegistrationDto account);
    }
}
