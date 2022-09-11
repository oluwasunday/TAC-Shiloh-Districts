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
        
        public IActionResult VideoStreams()
        {
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
