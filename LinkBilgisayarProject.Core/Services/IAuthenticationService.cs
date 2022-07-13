using LinkBilgisayarProject.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Services
{
    public interface IAuthenticationService
    {
        Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        Task<CustomResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken); // elegeçirilmiş tokenı etkisiz yapmak için metot

        CustomResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}
