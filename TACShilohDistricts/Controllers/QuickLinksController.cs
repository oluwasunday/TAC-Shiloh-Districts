﻿using Microsoft.AspNetCore.Mvc;
using TACShilohDistricts.Core.Enums;
using TACShilohDistricts.Core.IServices;
using TACShilohDistricts.Core.ViewModel;
using TACShilohDistricts.Services.Services;

namespace TACShilohDistricts.Controllers
{
    public class QuickLinksController : Controller
    {
        private readonly ITestimonyService _testimonyService;
        private readonly INewsAndEventsService _newsAndEventsService;

        public QuickLinksController(ITestimonyService testimonyService, INewsAndEventsService newsAndEventsService)
        {
            _testimonyService = testimonyService;
            _newsAndEventsService = newsAndEventsService;
        }

        public async Task<IActionResult> NewsAndEvents()
        {
            var newsAndEvents = await _newsAndEventsService.GetAllNewsAndEventsAsync();
            var vm = newsAndEvents.Data.Select(x => new NewsAndEventsVM
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                NewsPictureUrl = x.NewsPictureUrl,
                EventCategory = x.EventCategory,
                DateOfEvents = x.DateOfEvents
            }).ToList();

            var results = new NewsAndEventsViewModel
            {
                NewsAndEvents = vm,
                Categories = Enum.GetValues(typeof(EventCategory)).Cast<EventCategory>().ToList()
            };

            return View(results);
        }

        public async Task<IActionResult> NewsAndEventsById(string id)
        {
            var newsAndEvents = await _newsAndEventsService.GetAllNewsAndEventsByIdAsync(id);

            if (newsAndEvents.Succeeded)
            {
                var vm = new NewsAndEventsVM
                {
                    Title = newsAndEvents.Data.Title,
                    Id = newsAndEvents.Data.Id,
                    Description = newsAndEvents.Data.Description,
                    DateOfEvents = newsAndEvents.Data.DateOfEvents,
                    EventCategory = newsAndEvents.Data.EventCategory,
                    NewsPictureUrl = newsAndEvents.Data.NewsPictureUrl
                };

                var results = new NewsAndEventsViewModel
                {
                    NewsAndEventsById = vm,
                    Categories = Enum.GetValues(typeof(EventCategory)).Cast<EventCategory>().ToList()
                };

                return View(results);
            }

            
            return NotFound();
        }

        public IActionResult PrayerRequest()
        {
            return View();
        }

        public async Task<IActionResult> TestimoniesAsync()
        {
            var testimonies = await _testimonyService.GetAllTestimoniesAsync();
            var vm = new TestimoniesViewModel
            {
                Testimonies = testimonies
            };

            if (vm == null)
            {
                TempData["error"] = "error occur";
            }
            return View(vm);
        }
    }
}
