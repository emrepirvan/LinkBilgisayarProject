using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkBilgisayarProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAppController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserAppController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return CreateActionResult(await _userService.CreateUserAsync(createUserDto));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return CreateActionResult(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }
    }
}
