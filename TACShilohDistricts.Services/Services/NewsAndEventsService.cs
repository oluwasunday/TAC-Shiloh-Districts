using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Enums;
using TACShilohDistricts.Core.Handlers;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Core.IServices;

namespace TACShilohDistricts.Services.Services
{
    public class NewsAndEventsService : INewsAndEventsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsAndEventsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<NewsAndEvents>>> GetAllNewsAndEventsAsync()
        {
            var newsAndEvents = _unitOfWork.NewsAndEvents.GetAll();

            var response =  Response<List<NewsAndEvents>>.Success("success", newsAndEvents.OrderByDescending(x => x.DateOfEvents).ToList());
            return response;
        }

        public async Task<Response<NewsAndEvents>> GetAllNewsAndEventsByIdAsync(string id)
        {
            var newsAndEvent = await _unitOfWork.NewsAndEvents.GetAsync(x => x.Id == id);

            var response =  Response<NewsAndEvents>.Success("success", newsAndEvent);
            return response;
        }

        public async Task<Response<List<NewsAndEvents>>> GetAllNewsAndEventsByCategoryAsync(EventCategory category)
        {
            var newsAndEvents = _unitOfWork.NewsAndEvents.GetAll().Where(x => x.EventCategory == category);

            var response = Response<List<NewsAndEvents>>.Success("success", await newsAndEvents.OrderByDescending(x => x.DateOfEvents).ToListAsync());
            return response;
        }

        public async Task<Response<List<NewsAndEvents>>> GetLastTenNewsAndEventsAsync()
        {
            var newsAndEvents = _unitOfWork.NewsAndEvents.GetAll();

            var response = Response<List<NewsAndEvents>>.Success("success", newsAndEvents.OrderByDescending(x => x.DateOfEvents).Take(10).ToList());
            return response;
        }

        public async Task<Response<bool>> AddNewsAndEventsAsync(NewsAndEventsDto newsAndEvents)
        {
            var newsEvents = _mapper.Map<NewsAndEvents>(newsAndEvents);

            var test = Enum.TryParse(newsAndEvents.EventCategory, out EventCategory eventCategory);
            newsEvents.EventCategory = test ? eventCategory : newsEvents.EventCategory = EventCategory.General;

            _unitOfWork.NewsAndEvents.Add(newsEvents);
            await _unitOfWork.CompleteAsync();

            var response = Response<bool>.Success("success", true);
            return response;
        }
    }
}
