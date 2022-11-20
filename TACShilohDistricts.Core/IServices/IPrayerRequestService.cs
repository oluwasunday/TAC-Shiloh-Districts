using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Handlers;

namespace TACShilohDistricts.Core.IServices
{
    public interface IPrayerRequestService
    {
        Task<Response<PrayerRequest>> AddPrayerRequestAsync(PrayerRequestDto prayerRequest);
        Task<Response<List<PrayerRequest>>> GetLastTenPrayerRequestsAsync();
    }
}
