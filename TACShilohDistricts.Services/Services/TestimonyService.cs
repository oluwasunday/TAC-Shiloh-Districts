using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs.Testimony;
using TACShilohDistricts.Core.Entities;
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

        public async Task<List<TestimonyDto>> GetAllTestimoniesAsync()
        {
            var testimonies = _unitOfWork.Testimony.GetAll().OrderByDescending(x => x.CreatedAt);
            var allTestimonies = _mapper.Map<List<TestimonyDto>>(testimonies);
            return await Task.FromResult(allTestimonies.ToList());
        }
    }
}
