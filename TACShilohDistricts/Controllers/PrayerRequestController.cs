using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.IServices;

namespace TACShilohDistricts.Controllers
{
    public class PrayerRequestController : Controller
    {
        private readonly IPrayerRequestService _prayerRequest;

        public PrayerRequestController(IPrayerRequestService prayerRequest)
        {
            _prayerRequest = prayerRequest;
        }

        // GET: PrayerRequestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PrayerRequestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrayerRequestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrayerRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PrayerRequestDto prayerRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _prayerRequest.AddPrayerRequestAsync(prayerRequest);
                if (result.Succeeded)
                {
                    TempData["Response"] = "success";
                    return RedirectToAction("Index", "PrayerRequest");
                }
            }
            TempData["Response"] = "failed";
            return BadRequest(prayerRequest);
        }

        // GET: PrayerRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrayerRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrayerRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrayerRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
