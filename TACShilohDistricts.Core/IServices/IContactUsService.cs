using TACShilohDistricts.Core.DTOs;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Handlers;

namespace TACShilohDistricts.Core
{
    public interface IContactUsService
    {
        Task<Response<ContactUs>> AddContactUsAsync(ContactUsDto contactUsDto);
    }
}
