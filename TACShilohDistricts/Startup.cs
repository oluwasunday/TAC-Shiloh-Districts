using Microsoft.AspNetCore.Builder;
using TACShilohDistricts.Application.Mapper;
using TACShilohDistricts.Extensions;

namespace TACShilohDistricts
{
    public class Startup
    {
        public static IConfiguration StaticConfig { get; private set; }
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            StaticConfig = configuration;
            Environment = environment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextAndConfigurations(Environment, Configuration);

            // Register Dependency Injection Service Extension
            services.AddDependencyInjection();

            // Auto mapper
            services.AddAutoMapper(typeof(AutoMapperIntializer));
        }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
