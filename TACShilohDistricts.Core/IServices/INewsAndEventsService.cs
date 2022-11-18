using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Enums;
using TACShilohDistricts.Core.Handlers;

namespace TACShilohDistricts.Core.IServices
{
    public interface INewsAndEventsService
    {
        Task<Response<List<NewsAndEvents>>> GetAllNewsAndEventsAsync();
        Task<Response<NewsAndEvents>> GetAllNewsAndEventsByIdAsync(string id);
        Task<Response<List<NewsAndEvents>>> GetAllNewsAndEventsByCategoryAsync(EventCategory category);
        Task<Response<List<NewsAndEvents>>> GetLastTenNewsAndEventsAsync();
        Task<Response<bool>> AddNewsAndEventsAsync(NewsAndEventsDto newsAndEvents);
    }
}
