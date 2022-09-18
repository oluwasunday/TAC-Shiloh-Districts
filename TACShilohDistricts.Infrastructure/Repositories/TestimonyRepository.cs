using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Infrastructure.Data;
using TACShilohDistricts.Infrastructure.Repositories.Base;

namespace TACShilohDistricts.Core.IRepositories
{
    public class TestimonyRepository : Repository<Testimony>, ITestimonyRepository
    {
        private readonly TACShilohContext _context;
        public TestimonyRepository(TACShilohContext context) : base(context)
        {
            _context = context;
        }
    }
}
