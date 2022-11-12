using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Infrastructure.Data;
using TACShilohDistricts.Infrastructure.Repositories.Base;

namespace TACShilohDistricts.Infrastructure.Repositories
{
    public class NewsAndEventsRepository : Repository<NewsAndEvents>, INewsAndEventsRepository
    {
        private readonly TACShilohContext _context;
        public NewsAndEventsRepository(TACShilohContext context) : base(context)
        {
            _context = context;
        }
    }
}
