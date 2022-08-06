using TACShilohDistricts.Core;
using TACShilohDistricts.Core.IRepositories;
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
        }
    }
}
