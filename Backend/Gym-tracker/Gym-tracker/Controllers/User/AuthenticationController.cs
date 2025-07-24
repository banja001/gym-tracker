using Members.API.Dtos;
using Members.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace Gym_tracker.Controllers.User
{
    [Route("api/auth")]

    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public ActionResult<AuthenticationTokensDto> Login([FromBody] CredentialsDto credentials)
        {
            var result = _authenticationService.Login(credentials);
            return CreateResponse(result);
        }
        [HttpPost("register")]
        public ActionResult<AuthenticationTokensDto> Register([FromBody] AccountRegistrationDto account)
        {
            try
            {
                var result = _authenticationService.Register(account);

                return CreateResponse(result);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}
