using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TACShilohDistricts.Core;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.IRepositories;

namespace TACShilohDistricts.Services.Services
{
    public class ContactUsService: IContactUsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactUsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
