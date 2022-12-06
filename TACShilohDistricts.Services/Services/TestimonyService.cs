﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs.Testimony;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Handlers;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Core.IServices;

namespace TACShilohDistricts.Services.Services
{
    public class TestimonyService : ITestimonyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TestimonyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> AddTestimonyAsync(TestimonyDto dto)
        {
            if(dto == null)
            {
                return Response<bool>.Fail("Please fill all required information");
            }

            var testimony = _mapper.Map<Testimony>(dto);

            _unitOfWork.Testimony.Add(testimony);
            await _unitOfWork.CompleteAsync();

            return Response<bool>.Success("success", true);
        }

        public async Task<List<TestimonyDto>> GetAllTestimoniesAsync()
        {
            var testimonies = _unitOfWork.Testimony.GetAll().OrderByDescending(x => x.CreatedAt);
            var allTestimonies = _mapper.Map<List<TestimonyDto>>(testimonies);
            return await Task.FromResult(allTestimonies.ToList());
        }

        public async Task<Response<List<TestimonyDto>>> GetLastTenTestimoniesAsync()
        {
            var testimonies = _unitOfWork.Testimony.GetAll().OrderByDescending(x => x.CreatedAt);
            var allTestimonies = _mapper.Map<List<TestimonyDto>>(testimonies);
            var response = Response<List<TestimonyDto>>.Success("success", allTestimonies.OrderByDescending(x => x.TestifyerName).Take(10).ToList());

            return await Task.FromResult(response);
        }
    }
}
