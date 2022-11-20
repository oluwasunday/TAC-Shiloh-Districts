using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;
using TACShilohDistricts.Core.DTOs.AppUserDtos;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Core.IServices;

namespace TACShilohDistricts.Controllers
{
    //[Route("users")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        //private readonly IMailService _mailService;
        private IConfiguration _configuration;
        private readonly string _baseUrl;
        private IUserRepository _userRepo;

        public AuthController(IAuthService authService, IConfiguration configuration, IWebHostEnvironment web, IUserRepository userRepo)
        {
            _authService = authService;
            _configuration = configuration;
            _baseUrl = web.IsDevelopment() ? configuration["AppBaseUrl"] : configuration["HerokuUrl"];
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        // base-url/api/Auth/Login
        [HttpPost]
        //[Route("Login")]
        //[AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LoginAsync([FromForm] LoginDto model)
        {
            ViewBag.Success = false;
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginUserAsync(model);
                if (result.Succeeded)
                {
                    var user = new LoginResponseDto()
                    {
                        Id = result.Data.Id,
                        FirstName = result.Data.FirstName,
                        LastName = result.Data.LastName,
                        Avatar = result.Data.Avatar,
                        Email = result.Data.Email,
                        Age = result.Data.Age,
                        Gender = result.Data.Gender,
                        PhoneNumber = result.Data.PhoneNumber,
                        Token = result.Data.Token
                    };

                    var Role = result.Data.Roles;
                    HttpContext.Session.SetString("Username", JsonConvert.SerializeObject(user));
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    if (Role == null)
                    {
                        ModelState.AddModelError(string.Empty, "Unable to log you in at this time.");
                        return View();
                    }
                    else if (Role.Contains("Admin"))
                    {
                        ViewBag.AdminInfo = user;
                        TempData["Success"] = "good";
                        return RedirectToAction("Dashboard", "Admin", user);
                    }
                }


                //else if (Role == "Member")
                //{
                //    ViewBag.LogInfo = new { userId = result.Id, email = result.Email, name = $"{user.FirstName} {user.LastName}" };
                //    ViewBag.Username = $"{user.FirstName} {user.LastName}";
                //    return RedirectToAction("Index", "Home", ViewBag.LogInfo);//, new { userId = result.Id, email = result.Email, name = $"{user.FirstName} {user.LastName}" });
                //}                
                return RedirectToAction("Index", "Home");

            }            
            return BadRequest(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("TACNShilohUser");
            Response.Cookies.Delete("User");
            if (Request.Cookies["TACNShilohUser"] != null)
            {
                Response.Cookies.Delete("TACNShilohUser");
            }
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }
    }
}
