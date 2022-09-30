using Microsoft.AspNetCore.Mvc;
using TACShilohDistricts.Core.IServices;
using TACShilohDistricts.Core.ViewModel;

namespace TACShilohDistricts.Controllers
{
    public class QuickLinksController : Controller
    {
        private readonly ITestimonyService _testimonyService;

        public QuickLinksController(ITestimonyService testimonyService)
        {
            _testimonyService = testimonyService;
        }

        public IActionResult NewsAndEvents()
        {
            return View();
        }

        public IActionResult PrayerRequest()
        {
            return View();
        }

        public async Task<IActionResult> TestimoniesAsync()
        {
            var testimonies = await _testimonyService.GetAllTestimoniesAsync();
            var vm = new TestimoniesViewModel
            {
                Testimonies = testimonies
            };

            if (vm == null)
            {
                TempData["error"] = "error occur";
            }
            return View(vm);
            //return View();
        }
    }
}
