using Microsoft.AspNetCore.Mvc;
using TACShilohDistricts.Core.DTOs;

namespace TACShilohDistricts.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // POST: ContactUs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactUsDto dto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("Index");
            }
            
        }
    }
}
