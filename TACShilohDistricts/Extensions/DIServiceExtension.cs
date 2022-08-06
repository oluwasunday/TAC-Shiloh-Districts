using TACShilohDistricts.Core.IRepositories;
using TACShilohDistricts.Infrastructure.UnitOfWork;

namespace TACShilohDistricts.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            // unit of work injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
