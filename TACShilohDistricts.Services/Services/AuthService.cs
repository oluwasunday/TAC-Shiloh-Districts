using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Text;
using TACShilohDistricts.Core.DTOs.AppUserDtos;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Handlers;
using TACShilohDistricts.Core.IServices;

namespace TACShilohDistricts.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenGeneratorService _tokenGenerator;
        private IConfiguration _configuration;
        //private readonly IImageService _imageService;

        private readonly string _baseUrl = "";

        public AuthService(UserManager<AppUser> userManager, ITokenGeneratorService tokenGenerator, IConfiguration configuration, IWebHostEnvironment web)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
            _baseUrl = web.IsDevelopment() ? configuration["BaseUrl"] : configuration["HerokuUrl"];
        }

        public Task<Response<RegisterResponseDto>> RegisterUserAsync(RegisterDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<LoginResponseDto>> LoginUserAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new Response<LoginResponseDto>()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Succeeded = false,
                    Message = "No user with the specified email address",
                    Data = new LoginResponseDto { Id = null, Token = null }
                };

            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
                return new Response<LoginResponseDto>()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Succeeded = false,
                    Message = "Invalid password",
                    Data = new LoginResponseDto { Id = null, Token = null }
                };

            var token = await _tokenGenerator.GenerateToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            return new Response<LoginResponseDto>()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Login Successful",
                Succeeded = true,
                Data = new LoginResponseDto
                {
                    Id = user.Id,
                    Token = token,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Avatar = user.PictureUrl,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Age = user.Age,
                    Gender = user.Gender,
                    Roles = roles.ToList()
                }
            };
        }

        public async Task<Response<string>> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new Response<string>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Data = "Failed",
                    Message = "User not found",
                    Errors = null
                };
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}ResetPassword?email={email}&token={validToken}";

            //TODO: 
            //await _mailService.SendEmailAsync(new MailRequestDto
            //{
            //    ToEmail = email,
            //    Subject = "Reset Password",
            //    Body = $"<h1>Follow the instructions to reset your password</h1>\n<p>To reset your password, <a href='{url}'>click here</a></p>"
            //});

            return new Response<string>()
            {
                StatusCode = StatusCodes.Status200OK,
                Succeeded = true,
                Data = "Reset link sent to specified email",
                Message = "Successful",
                Errors = null
            };
        }

        /// <summary>
        /// Resets users password 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>success</returns>
        public async Task<Response<string>> ResetPasswordAsync(ResetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new Response<string>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Data = null,
                    Message = "User not found",
                    Errors = null
                };
            }

            if (model.ConfirmPassword != model.ConfirmPassword)
            {
                return new Response<string>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                    Data = "Failed",
                    Message = "Password and ConfirmPassword not match",
                    Errors = null
                };
            }

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            var normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);
            if (result.Succeeded)
            {
                return new Response<string>()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Succeeded = true,
                    Data = "Successful",
                    Message = "Password successfully reset",
                    Errors = null
                };
            }

            return new Response<string>()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Succeeded = false,
                Data = "Failed",
                Message = "Something went wrong",
                Errors = GetErrors(result)
            };
        }

        private static string GetErrors(IdentityResult result)
        {
            return result.Errors.Aggregate(string.Empty, (current, err) => current + err.Description + "\n");
        }
    }
}
