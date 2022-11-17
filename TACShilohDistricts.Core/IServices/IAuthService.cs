using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs.AppUserDtos;
using TACShilohDistricts.Core.Handlers;

namespace TACShilohDistricts.Core.IServices
{
    public interface IAuthService
    {
        Task<Response<RegisterResponseDto>> RegisterUserAsync(RegisterDto model);
        Task<Response<LoginResponseDto>> LoginUserAsync(LoginDto model);
        Task<Response<string>> ForgetPasswordAsync(string email);
        Task<Response<string>> ResetPasswordAsync(ResetPasswordDto model);
    }
}
