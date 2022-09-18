using Microsoft.AspNetCore.Mvc;
using TACShilohDistricts.Core.IServices;
using TACShilohDistricts.Core.ViewModel;

namespace TACShilohDistricts.Controllers
{
    public class TestimoniesController : Controller
    {
        private readonly ITestimonyService _testimonyService;

        public TestimoniesController(ITestimonyService testimonyService)
        {
            _testimonyService = testimonyService;
        }

        public async Task<IActionResult> Index()
        {
            var testimonies = await _testimonyService.GetAllTestimoniesAsync();
            var vm = new TestimoniesViewModel
            {
                Testimonies = testimonies
            };

            if(vm == null)
            {
                TempData["error"] = "error occur";
            }
            return View(vm);
        }
    }
}
