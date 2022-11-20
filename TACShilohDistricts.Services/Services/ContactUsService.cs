using AutoMapper;
using TACShilohDistricts.Core;
using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Handlers;
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

        public async Task<Response<ContactUs>> AddContactUsAsync(ContactUsDto contactUsDto)
        {
            var contact = _mapper.Map<ContactUs>(contactUsDto);

            if (contact != null)
            {
                _unitOfWork.ContactUs.Add(contact);
                await _unitOfWork.CompleteAsync();

                return Response<ContactUs>.Success("success", contact);
            }

            return Response<ContactUs>.Fail("something went wrong, check the data submitted");
        }

        public async Task<Response<List<ContactUs>>> GetLastTenContactMessageAsync()
        {
            var contacts = _unitOfWork.ContactUs.GetAllAsQueryable().Where(x => x.IsDeleted == false);

            if (contacts != null)
            {
                return await Task.FromResult(Response<List<ContactUs>>.Success("success", contacts.OrderByDescending(x => x.CreatedAt).Take(10).ToList()));
            }

            return await Task.FromResult(Response<List<ContactUs>>.Fail("something went wrong, check the data submitted"));
        }

        public async Task<Response<List<ContactUs>>> GetAllContactMessageAsync()
        {
            var contacts = _unitOfWork.ContactUs.GetAllAsQueryable().Where(x => x.IsDeleted == false);

            if (contacts != null)
            {
                return await Task.FromResult(Response<List<ContactUs>>.Success("success", contacts.OrderByDescending(x => x.CreatedAt).ToList()));
            }

            return await Task.FromResult(Response<List<ContactUs>>.Fail("something went wrong, check the data submitted"));
        }
    }
}
