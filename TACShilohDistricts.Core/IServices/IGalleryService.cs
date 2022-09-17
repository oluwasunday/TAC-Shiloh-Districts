using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs.Gallery;

namespace TACShilohDistricts.Core.IServices
{
    public interface IGalleryService
    {
        Task<List<GalleryDto>> GetAllPictures();
        Task<List<GalleryDto>> GetAllPicturesByCategory(string category);
        Task<List<GalleryDto>> AllGalleryCategories();
        Task<List<GalleryDto>> AllGalleriesByCategory(string category);
    }
}
