using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Handlers;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Core.IServices;

namespace TACShilohDistricts.Services.Services
{
    public class PrayerRequestService: IPrayerRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrayerRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<PrayerRequest>> AddPrayerRequestAsync(PrayerRequestDto prayerRequest)
        {
            var request = _mapper.Map<PrayerRequest>(prayerRequest);

            if (request != null)
            {
                _unitOfWork.PrayerRequest.Add(request);
                await _unitOfWork.CompleteAsync();

                return Response<PrayerRequest>.Success("success", request);
            }

            return Response<PrayerRequest>.Fail("something went wrong, check the data submitted");
        }

        public async Task<Response<List<PrayerRequest>>> GetLastTenPrayerRequestsAsync()
        {
            var requests = _unitOfWork.PrayerRequest.GetAll();

            var response = await Task.FromResult(Response<List<PrayerRequest>>.Success("success", requests.OrderByDescending(x => x.CreatedAt).Take(10).ToList()));
            return response;
        }
    }
}
