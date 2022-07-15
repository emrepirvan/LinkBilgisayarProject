using LinkBilgisayarProject.Core.Configuration;
using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Entites;
using LinkBilgisayarProject.Core.Repositories;
using LinkBilgisayarProject.Core.Services;
using LinkBilgisayarProject.Core.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinkBilgisayarProject.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;
        //private readonly RoleManager<UserApp> _roleManager;

        public AuthenticationService(IOptions<List<Client>> optionClients, ITokenService tokenService, UserManager<UserApp> userManager, IUnitOfWork unitOfWork, IGenericRepository<UserRefreshToken> serviceGeneric/*, RoleManager<UserApp> roleManager*/)
        {
            _clients = optionClients.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = serviceGeneric;
            //_roleManager = roleManager;
        }

        public async Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                throw new ArgumentNullException(nameof(LoginDto));
            }
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return CustomResponseDto<TokenDto>.Fail( 400, "Email or Password is wrong ", true);
            }
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return CustomResponseDto<TokenDto>.Fail( 400, "Email or Password is wrong ", true);
            }

            var token = _tokenService.CreateToken(user);

            var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new UserRefreshToken { UserId = user.Id, RefreshToken = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.RefreshToken = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<TokenDto>.Success( 200,token);

        }

        public CustomResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientId && x.Secret == clientLoginDto.ClientSecret);

            if (client == null)
            {
                return CustomResponseDto<ClientTokenDto>.Fail( 404, "ClientId or ClietSecret not found", true);
            }
            var token = _tokenService.CreateTokenByClient(client);
            return CustomResponseDto<ClientTokenDto>.Success( 200, token);
        }

        public async Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.Where(x => x.RefreshToken == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return CustomResponseDto<TokenDto>.Fail( 404, "Refresh Token not found", true);
            }
            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null)
            {
                return CustomResponseDto<TokenDto>.Fail( 404, "UserId not found", true);
            }
            var tokenDto = _tokenService.CreateToken(user);

            existRefreshToken.RefreshToken = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;


            await _unitOfWork.CommitAsync();

            return CustomResponseDto<TokenDto>.Success( 200,tokenDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.Where(x => x.RefreshToken == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "RefreshToken not found",true);
            }
            _userRefreshTokenService.Remove(existRefreshToken);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(200);
        }
    }
}
