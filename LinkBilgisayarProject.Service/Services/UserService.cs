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
        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

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
