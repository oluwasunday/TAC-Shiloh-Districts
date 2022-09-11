using Microsoft.AspNetCore.Mvc;

namespace TACShilohDistricts.Controllers
{
    public class VideoStreamsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
