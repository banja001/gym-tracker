using AutoMapper;
using BuildingBlocks.Core.Security;
using BuildingBlocks.Core.UseCases;
using FluentResults;
using Members.API.Dtos;
using Members.API.Public;
using Members.Core.Domain;
using Members.Core.Domain.RepositoryInterfaces;
using System;
using System.Text.RegularExpressions;

namespace Members.Core.UseCases
{
    public class AuthenticationService : BaseService<UserDto,User>, IAuthenticationService
    {
        private static readonly Regex PasswordRegex = new Regex(@"^(?=.*\d).{6,}$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(2000));

        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository, ITokenGenerator tokenGenerator, IMapper mapper) : base(mapper)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        public Result<AuthenticationTokensDto> Login(CredentialsDto credentials)
        {
            var user = _userRepository.GetByUsername(credentials.Username);
            if (user == null || !PasswordEncoder.Matches(credentials.Password, user.Password)) return Result.Fail(FailureCode.NotFound);
            //if (user == null || !Equals(credentials.Password, user.Password)) return Result.Fail(FailureCode.NotFound);
            var tokens = _tokenGenerator.GenerateAccessAndRefreshToken(user);
            _userRepository.SetRefreshToken(user.Username, tokens.Value.RefreshToken);
            return tokens;
        }

        public Result<RegisteredUserDto> Register(AccountRegistrationDto account)
        { 
            if(_userRepository.Exists(account.Username))
                return Result.Fail(FailureCode.NonUniqueUsername);
            try
            {
                if (!string.IsNullOrWhiteSpace(account.Password) && !PasswordRegex.IsMatch(account.Password))
                    throw new ArgumentException("Invalid Password format. Password must be at least 6 characters long and include at least one number.");
                var user = _userRepository.Create(new User(account.FirstName, account.LastName, account.Username, PasswordEncoder.Encode(account.Password)));
                var refreshToken = _tokenGenerator.GenerateAccessAndRefreshToken(user);
                user.RefreshToken = refreshToken.Value.RefreshToken;
                user = _userRepository.Update(user);

                return new RegisteredUserDto(user.Id, user.Username);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }
        public Result<AuthenticationTokensDto> Refresh(AuthenticationTokensDto tokens)
        {
            User user = _userRepository.Get(getUserIdFromToken(tokens.AccessToken));
            if (user.RefreshToken != tokens.RefreshToken)
            {
                return null;
            }
            AuthenticationTokensDto newJwtTokens = _tokenGenerator.GenerateAccessAndRefreshToken(user).Value;
            if (newJwtTokens == null)
            {
                return null;
            }
            _userRepository.SetRefreshToken(user.Username, newJwtTokens.RefreshToken);
            return newJwtTokens;
        }
        private long getUserIdFromToken(string token)
        {
            return _tokenGenerator.GetUserIdFromToken(token);
        }
    }
}
