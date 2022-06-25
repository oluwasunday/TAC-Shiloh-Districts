using Microsoft.AspNetCore.Mvc;

namespace TACShilohDistricts.Controllers
{
    public class DoctrineAndBeliefController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
