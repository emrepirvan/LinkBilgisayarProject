using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkBilgisayarProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var token = await _authenticationService.CreateTokenAsync(loginDto);

            return CreateActionResult(token);
        }

        [HttpPost]
        public IActionResult CreateTokenByCliennt(ClientLoginDto clientLoginDto)
        {
            var token = _authenticationService.CreateTokenByClient(clientLoginDto);

            return CreateActionResult(token);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var token = await _authenticationService.RevokeRefreshToken(refreshTokenDto.RefreshToken);

            return CreateActionResult(token);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var token = await _authenticationService.CreateTokenByRefreshToken(refreshTokenDto.RefreshToken);

            return CreateActionResult(token);
        }
    }
}
