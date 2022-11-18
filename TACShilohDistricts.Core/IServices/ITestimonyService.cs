using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs.Testimony;
using TACShilohDistricts.Core.Handlers;

namespace TACShilohDistricts.Core.IServices
{
    public interface ITestimonyService
    {
        Task<List<TestimonyDto>> GetAllTestimoniesAsync();
        Task<Response<List<TestimonyDto>>> GetLastTenTestimoniesAsync();
    }
}
