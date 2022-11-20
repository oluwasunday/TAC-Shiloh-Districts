using Microsoft.AspNetCore.Mvc;
using TACShilohDistricts.Core;
using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.Entities;
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
        private IContactUsService _contactService;
        private INewsAndEventsService _newsAndEventsService;
        private IPrayerRequestService _prayerRequestService;
        private ITestimonyService _testimonyService;
        private IGalleryService _galleryService;

        public AdminController(IAuthService authService, IConfiguration configuration, IWebHostEnvironment web,
            IUserRepository userRepo, IContactUsService contactService, INewsAndEventsService newsAndEventsService,
            IPrayerRequestService prayerRequestService, ITestimonyService testimonyService, IGalleryService galleryService)
        {
            _authService = authService;
            _configuration = configuration;
            _baseUrl = web.IsDevelopment() ? configuration["AppBaseUrl"] : configuration["HerokuUrl"];
            _userRepo = userRepo;
            _contactService = contactService;
            _newsAndEventsService = newsAndEventsService;
            _prayerRequestService = prayerRequestService;
            _testimonyService = testimonyService;
            _galleryService = galleryService;
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

        public async Task<IActionResult> LastTenContacts()
        {
            var users = await _contactService.GetLastTenContactMessageAsync();

            if (users.Data != null)
            {
                var vm = new ContactsViewModel
                {
                    Contacts = users.Data,
                    Email = HttpContext.Session.GetString("UserEmail") != null ? HttpContext.Session.GetString("UserEmail") : "usermail"
                };
                return View(vm);                
            }
            return View();
        }

        public async Task<IActionResult> Contacts()
        {
            var users = await _contactService.GetLastTenContactMessageAsync();

            if (users.Data != null)
            {
                var vm = new ContactsViewModel
                {
                    Contacts = users.Data,
                    Email = HttpContext.Session.GetString("UserEmail") != null ? HttpContext.Session.GetString("UserEmail") : "usermail"
                };
                return View(vm);                
            }
            return View();
        }

        public async Task<IActionResult> LastTenNewsAndEvents()
        {
            var newsEvents = await _newsAndEventsService.GetLastTenNewsAndEventsAsync();

            if (newsEvents.Data != null)
            {
                var vm = new NewsEventsViewModel
                {
                    NewsAndEvents = newsEvents.Data,
                    Email = HttpContext.Session.GetString("UserEmail") != null ? HttpContext.Session.GetString("UserEmail") : "usermail"
                };
                return View(vm);                
            }
            return View();
        }

        public async Task<IActionResult> NewsAndEvents()
        {
            var newsEvents = await _newsAndEventsService.GetAllNewsAndEventsAsync();

            if (newsEvents.Data != null)
            {
                var vm = new NewsEventsViewModel
                {
                    NewsAndEvents = newsEvents.Data,
                    Email = HttpContext.Session.GetString("UserEmail") != null ? HttpContext.Session.GetString("UserEmail") : "usermail"
                };
                return View(vm);                
            }
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddNewsAndEvents(NewsAndEventsDto newsAndEvents)
        {
            if (ModelState.IsValid)
            {
                var response = await _newsAndEventsService.AddNewsAndEventsAsync(newsAndEvents);

                if (response.Data)
                {
                    return RedirectToAction("LastTenNewsAndEvents");
                }
            }
            
            return BadRequest(newsAndEvents);
        }

        public async Task<IActionResult> LastTenPrayerRequests()
        {
            var response = await _prayerRequestService.GetLastTenPrayerRequestsAsync();

            if (response.Data != null)
            {
                var vm = new PrayerRequestViewModel
                {
                    PrayerRequests = response.Data,
                    Email = HttpContext.Session.GetString("UserEmail") != null ? HttpContext.Session.GetString("UserEmail") : "usermail"
                };
                return View(vm);
            }
            return View();
        }

        public async Task<IActionResult> LastTenTestimonies()
        {
            var response = await _testimonyService.GetLastTenTestimoniesAsync();

            if (response.Data != null)
            {
                var vm = new TestimonyViewModel
                {
                    Testimonies = response.Data,
                    Email = HttpContext.Session.GetString("UserEmail") != null ? HttpContext.Session.GetString("UserEmail") : "usermail"
                };
                return View(vm);
            }
            return View();
        }

        public async Task<IActionResult> LastTenGallery()
        {
            var response = await _galleryService.GetLastTenGalleries();

            if (response.Data != null)
            {
                var vm = new GalleryViewModel
                {
                    Galleries = response.Data,
                    Email = HttpContext.Session.GetString("UserEmail") != null ? HttpContext.Session.GetString("UserEmail") : "usermail"
                };
                return View(vm);
            }
            return View();
        }
    }
}
