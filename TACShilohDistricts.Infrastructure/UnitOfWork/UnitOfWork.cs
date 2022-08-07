using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Infrastructure.Data;
using TACShilohDistricts.Infrastructure.Repositories;

namespace TACShilohDistricts.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IContactUsRepository ContactUs { get; }
        public IPrayerRequestRepository PrayerRequest { get; }

        private readonly TACShilohContext _context;

        public UnitOfWork(TACShilohContext context)
        {
            _context = context;
            ContactUs = new ContactUsRepository(_context);
            PrayerRequest = new PrayerRequestRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
