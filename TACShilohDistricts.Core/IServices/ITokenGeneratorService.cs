using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.Entities;

namespace TACShilohDistricts.Core.IServices
{
    public interface ITokenGeneratorService
    {
        Task<string> GenerateToken(AppUser appUser);
    }
}
