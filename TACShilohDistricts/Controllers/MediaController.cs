using Microsoft.AspNetCore.Mvc;
using TACShilohDistricts.Core.IServices;
using TACShilohDistricts.Core.ViewModel;

namespace TACShilohDistricts.Controllers
{
    public class MediaController : Controller
    {
        private readonly IGalleryService _galleryService;

        public MediaController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

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
        
        public async Task<IActionResult> Index()
        {
            //var allPics = await _galleryService.GetAllPictures();
            var allPics = await _galleryService.AllGalleryCategories();
            var galleries = new AllPicsViewModel
            {
                Galleries = allPics
            };
            return View(galleries);
        }
    }
}
