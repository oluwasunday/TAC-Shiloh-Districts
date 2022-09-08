using Microsoft.AspNetCore.Mvc;

namespace TACShilohDistricts.Controllers
{
    public class QuickLinksController : Controller
    {
        public IActionResult NewsAndEvents()
        {
            return View();
        }
    }
}
