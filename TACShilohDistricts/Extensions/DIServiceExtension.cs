using TACShilohDistricts.Core;
using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Core.IServices;
using TACShilohDistricts.Infrastructure.UnitOfWork;
using TACShilohDistricts.Services.Services;

namespace TACShilohDistricts.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            // unit of work injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // all services
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IPrayerRequestService, PrayerRequestService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<ITestimonyService, TestimonyService>();
            services.AddScoped<INewsAndEventsService, NewsAndEventsService>();
        }
    }
}
