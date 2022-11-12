using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs.Testimony;

namespace TACShilohDistricts.Core.IServices
{
    public interface ITestimonyService
    {
        Task<List<TestimonyDto>> GetAllTestimoniesAsync();
    }
}
