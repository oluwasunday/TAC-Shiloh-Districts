using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TACShilohDistricts;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Infrastructure.Data;
using TACShilohDistricts.Infrastructure.Seeding;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 8;
    //options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<TACShilohContext>()
        .AddEntityFrameworkStores<TACShilohContext>()
        .AddDefaultTokenProviders();

var startup = new Startup(builder.Configuration, builder.Environment);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TACShilohContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    //TACSeeder.SeedData(dbContext, userManager, roleManager).Wait();
    // use context
    startup.Configure(app, dbContext, userManager, roleManager);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

string? port = Environment.GetEnvironmentVariable("PORT"); if (!string.IsNullOrWhiteSpace(port)) { app.Urls.Add("http://*:" + port); }
app.Run();























//namespace TACShilohDistricts
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            //IConfigurationRoot configuration = new ConfigurationBuilder()
//            //    .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true).Build();

//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();//.UseSerilog();
//                });

//    }
//}