using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Infrastructure.Data;
using TACShilohDistricts.Infrastructure.Repositories.Base;

namespace TACShilohDistricts.Infrastructure.Repositories
{
    public class GalleryRepository : Repository<Gallery>, IGalleryRepository
    {
        private readonly TACShilohContext _context;
        public GalleryRepository(TACShilohContext context) : base(context)
        {
            _context = context;
        }
    }
}
