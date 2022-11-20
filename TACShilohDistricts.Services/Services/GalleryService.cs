using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Core;
using TACShilohDistricts.Core.IServices;
using TACShilohDistricts.Core.DTOs.Gallery;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Handlers;
using TACShilohDistricts.Core.DTOs;

namespace TACShilohDistricts.Services.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GalleryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GalleryDto>> GetAllPictures()
        {
            var galleries = _unitOfWork.Gallery.GetAll().OrderByDescending(x => x.CreatedAt);
            var allPics = _mapper.Map<List<GalleryDto>>(galleries);

            return await Task.FromResult(allPics);
        }

        public async Task<List<GalleryDto>> GetAllPicturesByCategory(string category)
        {
            var galleries = _unitOfWork.Gallery.GetAll().Where(x => x.Category == category).OrderByDescending(x => x.CreatedAt);
            var allPics = _mapper.Map<List<GalleryDto>>(galleries);

            return await Task.FromResult(allPics);
        }

        public async Task<List<GalleryDto>> AllGalleryCategories()
        {
            var categories = new HashSet<string>();

            categories = _unitOfWork.Gallery.GetAll().Select(x => x.Category).ToHashSet();

            var galleries = new List<Gallery>();
            foreach (var item in categories)
            {
                galleries.Add(_unitOfWork.Gallery.GetAll().Where(x => x.Category == item).FirstOrDefault());
            }

            //var galleryCategories = _unitOfWork.Gallery.GetAll().Where(x => categories.Contains(x.Category));
            var allPics = _mapper.Map<List<GalleryDto>>(galleries);

            return await Task.FromResult(allPics);
        }

        public async Task<List<GalleryDto>> AllGalleriesByCategory(string category)
        {
            var gallery = _unitOfWork.Gallery.GetAll().Where(x => x.Category == category);
            var allPics = _mapper.Map<List<GalleryDto>>(gallery);

            return await Task.FromResult(allPics);
        }

        public async Task<Response<List<GalleryDto>>> GetLastTenGalleries()
        {
            var galleries = _unitOfWork.Gallery.GetAll().OrderByDescending(x => x.CreatedAt).Take(10);
            var allPics = _mapper.Map<List<GalleryDto>>(galleries);

            var response = Response<List<GalleryDto>>.Success("success", allPics);
            return await Task.FromResult(response);
        }

        public async Task<Response<Gallery>> AddGalleryAsync(GalleryDto galleryDto)
        {
            var gallery = _mapper.Map<Gallery>(galleryDto);

            if (gallery != null)
            {
                _unitOfWork.Gallery.Add(gallery);
                await _unitOfWork.CompleteAsync();

                return Response<Gallery>.Success("success", gallery);
            }

            return Response<Gallery>.Fail("something went wrong, check the data submitted");
        }
    }
}
