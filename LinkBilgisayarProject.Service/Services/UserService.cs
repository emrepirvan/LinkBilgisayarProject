using AutoMapper;
using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Entites;
using LinkBilgisayarProject.Core.Services;
using LinkBilgisayarProject.Service.Mapping;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<RoleApp> _roleManager;
        public UserService(UserManager<UserApp> userManager, RoleManager<RoleApp> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new() { Name = UserRoles.Admin });
            if (!await _roleManager.RoleExistsAsync(UserRoles.Editor))
                await _roleManager.CreateAsync(new() { Name = UserRoles.Editor });
            var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };
            if (!(createUserDto.UserRole == UserRoles.Admin || createUserDto.UserRole == UserRoles.Editor))
            {
                return CustomResponseDto<UserAppDto>.Fail(404, "role not found or change first char with uppercase", true);
            }




            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, createUserDto.UserRole);
            }

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return CustomResponseDto<UserAppDto>.Fail( 400, new ErrorDto(errors, true));
            }
            //return CustomResponseDto<UserAppDto>.Success(_mapper.Map<UserAppDto>(200), 200);
            return CustomResponseDto<UserAppDto>.Success( 200, ObjectMapper.Mapper.Map<UserAppDto>(user));
        }

        public async Task<CustomResponseDto<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return CustomResponseDto<UserAppDto>.Fail( 404, "UserName Not found", true);
            }
            return CustomResponseDto<UserAppDto>.Success( 200, ObjectMapper.Mapper.Map<UserAppDto>(user));
        }
    }
}
