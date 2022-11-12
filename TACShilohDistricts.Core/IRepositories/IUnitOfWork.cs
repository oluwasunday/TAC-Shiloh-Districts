using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.IServices;

namespace TACShilohDistricts.Core.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IContactUsRepository ContactUs { get; }
        IPrayerRequestRepository PrayerRequest { get; }
        IGalleryRepository Gallery { get; }
        ITestimonyRepository Testimony { get; }
        INewsAndEventsRepository NewsAndEvents { get; }
        Task CompleteAsync();
        
    }
}
