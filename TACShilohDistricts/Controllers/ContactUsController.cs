using Microsoft.AspNetCore.Mvc;
using TACShilohDistricts.Core;
using TACShilohDistricts.Core.DTOs;

namespace TACShilohDistricts.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contact;

        public ContactUsController(IContactUsService contact)
        {
            _contact = contact;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: ContactUs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactUsDto dto)
        {
            
            var result = await _contact.AddContactUsAsync(dto);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "ContactUs");
            }
            return BadRequest(dto);
        }
    }
}
