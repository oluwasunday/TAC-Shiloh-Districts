using Microsoft.AspNetCore.Mvc;

namespace TACShilohDistricts.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
