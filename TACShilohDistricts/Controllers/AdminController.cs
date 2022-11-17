using Microsoft.AspNetCore.Mvc;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Core.IServices;
using TACShilohDistricts.Core.ViewModel;

namespace TACShilohDistricts.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAuthService _authService;
        private IConfiguration _configuration;
        private readonly string _baseUrl;
        private IUserRepository _userRepo;

        public AdminController(IAuthService authService, IConfiguration configuration, IWebHostEnvironment web, IUserRepository userRepo)
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

        public async Task<IActionResult> Dashboard()
        {
            ViewBag.ErrorCode = HttpContext.Session.GetString("ErrorCode");

            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (userEmail != null)
            {
                var user = await _userRepo.GetUserByEmailAsync(userEmail);
                var allRoles = await _userRepo.AllUsersRoles();

                user.Data.TotalMembers = allRoles.TotalMembers;
                user.Data.TotalPastors = allRoles.TotalPastors;
                user.Data.TotalProphets = allRoles.TotalProphets;
                user.Data.TotalElders = allRoles.TotalElders;

                if (user != null)
                {
                    return View(user.Data);
                }
            }
            ViewBag.ErrorInfo = "Please enter valid credentials";
            return View();
        }

        public async Task<IActionResult> Users()
        {
            var users = await _userRepo.GetLastTenUsersAsync();

            if (users != null)
            {
                var vm = new UsersViewModel
                {
                    AddUserResponse = users,
                    Email = HttpContext.Session.GetString("UserEmail")
            };
                return View(vm);                
            }
            return View();
        }
    }
}
