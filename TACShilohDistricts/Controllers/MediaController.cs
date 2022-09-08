using Microsoft.AspNetCore.Mvc;

namespace TACShilohDistricts.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Gallery()
        {
            return View();
        }
        
        public IActionResult VideoStream()
        {
            return View();
        }
    }
}
